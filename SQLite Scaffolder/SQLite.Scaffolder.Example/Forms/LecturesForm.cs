using SQLite.Scaffolder.Example.Repositories;
using SQLite.Scaffolder.Example.SimpleDatabase.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLite.Scaffolder.Example.Forms
{
    public partial class LecturesForm : Form
    {
        LectureRepository LectureRepo = new LectureRepository();

        public LecturesForm()
        {
            InitializeComponent();
            RefreshLecture();
        }

        private void RefreshLecture()
        {
            ListboxLectures.DataSource = LectureRepo.GetAll();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if(ListboxLectures.SelectedItem != null)
            {
                Lecture lecture = ListboxLectures.SelectedItem as Lecture;
                //first remove all references and connections to this lecture form other objects in the database
                LectureRepo.RemoveAllConnectionsToLecture(lecture);
                LectureRepo.Delete(lecture);

                RefreshLecture();
            }
        }

        private void OnLectureChanged(object sender, EventArgs e)
        {
            Lecture selectedLecture = ListboxLectures.SelectedItem as Lecture;

            TextboxName.Text = selectedLecture.Name;
            TextboxDescription.Text = selectedLecture.Description;

            using (MemoryStream ms = new MemoryStream(selectedLecture.ImageBytes))
            {
                PictureboxLectureImage.Image = Image.FromStream(ms);
            }
               
        }
    }
}
