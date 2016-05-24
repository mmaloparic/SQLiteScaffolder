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
    public partial class InsertStudentForm : Form
    {

        StudentRepository StudentRepo = new StudentRepository();
        List<Lecture> SelectedLectures = new List<Lecture>();
        
        public InsertStudentForm()
        {
            InitializeComponent();
        }

        private void ButtonEditLectures_Click(object sender, EventArgs e)
        {
            LecturesSelector form = new LecturesSelector();
            form.ShowDialog();
            SelectedLectures = form.SelectedLectures;
            ListboxLectures.DataSource = SelectedLectures;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TextboxName.Text) || string.IsNullOrEmpty(TextboxLastname.Text))
            {
                MessageBox.Show("Please fill in all the data", "Validation issue", MessageBoxButtons.OK);
            }
            else
            {
                StudentRepo.Insert(TextboxName.Text, TextboxLastname.Text, DateTimePickerBirthday.Value, SelectedLectures);
                this.Close();
            }
        }
    }
}
