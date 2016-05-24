using SQLite.Scaffolder.Example.Repositories;
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
    public partial class InsertLecture : Form
    {
        LectureRepository LectureRepo = new LectureRepository();

        public InsertLecture()
        {
            InitializeComponent();
        }

        private void ButtonSelectPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.ShowDialog();
            PictureBoxLectureImage.Load(dialog.FileName);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TextboxName.Text) || string.IsNullOrEmpty(TextboxDescription.Text))
            {
                MessageBox.Show("Please fill in all the data", "Validation issue", MessageBoxButtons.OK);
            }
            else
            {
                byte[] imageBytes = ConvertImageToBytes(PictureBoxLectureImage.Image);
                LectureRepo.Insert(TextboxName.Text, TextboxDescription.Text, imageBytes);
                this.Close();
            }
        }

        public byte[] ConvertImageToBytes(System.Drawing.Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
