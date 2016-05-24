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
    public partial class LecturesSelector : Form
    {
        //PUBLIC PROPERTIES
        public List<Lecture> SelectedLectures { get; set; }



        //PRIVATE FIELDS
        private LectureRepository LectureRepo = new LectureRepository();
        private StudentRepository StudentRepo = new StudentRepository();



        //CONSTRUCTORS
        public LecturesSelector()
        {
            InitializeComponent();
            List<Lecture> allLectures = LectureRepo.GetAll();
            foreach (var lecture in allLectures)
            {
                CheckedListBoxLectures.Items.Add(lecture, false);
            }
        }

        public LecturesSelector(Student student)
        {
            InitializeComponent();
            List<Lecture> allLectures = LectureRepo.GetAll();
            List<Lecture> alreadySelectedLectures = StudentRepo.GetLectures(student);

            foreach(var lecture in allLectures)
            {
                CheckedListBoxLectures.Items.Add(lecture, alreadySelectedLectures.Contains(lecture));
            }            
        }


        private void LecturesSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            SelectedLectures = new List<Lecture>();
            foreach (var lecture in CheckedListBoxLectures.CheckedItems)
            {
                SelectedLectures.Add(lecture as Lecture);
            }
        }
    }
}
