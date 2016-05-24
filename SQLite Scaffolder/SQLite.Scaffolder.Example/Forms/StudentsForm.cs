using SQLite.Scaffolder.Example.Repositories;
using SQLite.Scaffolder.Example.SimpleDatabase.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLite.Scaffolder.Example.Forms
{
    public partial class StudentsForm : Form
    {
        StudentRepository StudentRepo = new StudentRepository();
        bool AddingNew = false;

        public StudentsForm()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {           
            List<Student> students = StudentRepo.GetAll();
            ListboxStudents.DataSource = students;
        }

        private void OnStudentSelected(object sender, EventArgs e)
        {
            Student selectedStudent = ListboxStudents.SelectedItem as Student;
            if(selectedStudent != null)
            {
                PopulateFields(selectedStudent);
            }
        }

        private void PopulateFields(Student selectedStudent)
        {
            TextboxName.Text = selectedStudent.Name;
            TextboxLastname.Text = selectedStudent.Lastname;
            DateTimePickerBirthday.Value = selectedStudent.Birthday;
            LoadLecturesForStudent(selectedStudent);
        }

        private void LoadLecturesForStudent(Student selectedStudent)
        {
            List<Lecture> studentsLectures = StudentRepo.GetLectures(selectedStudent);
            ListboxLectures.DataSource = studentsLectures;
        }
    }
}
