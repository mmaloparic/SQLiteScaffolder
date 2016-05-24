using SQLite.Scaffolder.Example.SimpleDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SQLite.Scaffolder.Example.Repositories
{
    public class LectureRepository : BaseRepository
    {
        public List<Lecture> GetAll()
        {
            return Database.Lectures.SelectAll().ToList();
        }

        public void Insert(string name, string description, byte[] imageBytes)
        {
            Lecture l = new Lecture();
            l.ID = Guid.NewGuid();
            l.Name = name;
            l.Description = description;
            l.ImageBytes = imageBytes;

            Database.Lectures.Insert(l);
        }

        public void RemoveAllConnectionsToLecture(Lecture lecture)
        {
            string whereCondition = string.Format("WHERE LectureId = '{0}'", lecture.ID);
            List<StudentLecture> connectionsForLecture = Database.StudentLecture.SelectAll(whereCondition).ToList();
            Database.StudentLecture.DeleteRange(connectionsForLecture);
        }

        public void Delete(Lecture lecture)
        {
            Database.Lectures.Delete(lecture);
        }
    }
}
