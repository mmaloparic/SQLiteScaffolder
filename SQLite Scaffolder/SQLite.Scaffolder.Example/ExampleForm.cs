using SQLite.Scaffolder.Example.Forms;
using SQLite.Scaffolder.Example.SimpleDatabase;
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

namespace SQLite.Scaffolder.Example
{
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
        }

        private void ToolstripStudents_Click(object sender, EventArgs e)
        {
            StudentsForm form = new StudentsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void ToolstripAddStudent_Click(object sender, EventArgs e)
        {
            InsertStudentForm form = new InsertStudentForm();
            form.MdiParent = this;
            form.Show();
        }

        private void ToolstripInsertLecture_Click(object sender, EventArgs e)
        {
            InsertLecture form = new InsertLecture();
            form.MdiParent = this;
            form.Show();
        }

        private void ToolstripLectures_Click(object sender, EventArgs e)
        {
            LecturesForm form = new LecturesForm();
            form.MdiParent = this;
            form.Show();
        }        
    }
}
