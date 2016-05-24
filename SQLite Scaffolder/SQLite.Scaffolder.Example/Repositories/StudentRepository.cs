using SQLite.Scaffolder.Example.SimpleDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Example.Repositories
{
    public class StudentRepository : BaseRepository
    {
        public bool Insert(string name, string lastname, DateTime birthday, List<Lecture> selectedLectures = null)
        {
            Student s = new Student();
            s.ID = Guid.NewGuid();
            s.Name = name;
            s.Lastname = lastname;
            s.Birthday = birthday;

            var insertReport = this.Database.Students.Insert(s);

            //attach the lectures on the studnet, if any are specified
            if(selectedLectures != null && selectedLectures.Any())
            {
                List<StudentLecture> studentToLectureConnections = new List<StudentLecture>();
                foreach(Lecture nextLecture in selectedLectures)
                {
                    StudentLecture connection = new StudentLecture { StudentId = s.ID, LectureId = nextLecture.ID };
                    studentToLectureConnections.Add(connection);
                }

                var insertLectureConnectionsReport = Database.StudentLecture.InsertRange(studentToLectureConnections);

                return insertLectureConnectionsReport.IsSuccess && insertReport.IsSuccess;
            }
            else
            {
                return insertReport.IsSuccess;
            }

            
        }

        public List<Student> GetAll()
        {
            return Database.Students.SelectAll().ToList();
        }

        public bool Update(Student student)
        {
            var updateReport = Database.Students.Update(student);
            return updateReport.IsSuccess;
        }

        public bool Delete(Student student)
        {
            var deleteReport = Database.Students.Delete(student);
            return deleteReport.IsSuccess;
        }

        public bool SetLectures(Student student, List<Lecture> lectures)
        {
            //remove the old lecture connections
            string whereCondition = string.Format("WHERE StudentId = {0}", student.ID);
            List<StudentLecture> studentsLectures = Database.StudentLecture.SelectAll(whereCondition).ToList();

            foreach (var oldLecture in studentsLectures)
            {
                Database.StudentLecture.Delete(oldLecture);
            }

            //add the new values
            List<StudentLecture> lecturesToBeAdded = new List<StudentLecture>();
            foreach(var lecture in lectures)
            {
                StudentLecture nextLectureOnStudent = new StudentLecture { LectureId = lecture.ID, StudentId = student.ID };
                lecturesToBeAdded.Add(nextLectureOnStudent);
            }

            var insertReport = Database.StudentLecture.InsertRange(lecturesToBeAdded);
            return insertReport.IsSuccess;
        }

        public List<Lecture> GetLectures(Student student)
        {
            string whereCondition = string.Format("INNER JOIN StudentLecture ON Lecture.Id = StudentLecture.LectureId WHERE StudentLecture.StudentId = '{0}'", student.ID);
            List<Lecture> lectures = Database.Lectures.SelectAll(whereCondition).ToList();
            return lectures;
        }
    }
}
