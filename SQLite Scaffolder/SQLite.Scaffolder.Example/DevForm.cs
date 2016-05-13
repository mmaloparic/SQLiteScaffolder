using SQLite.Scaffolder.Example.SimpleDatabase;
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

namespace SQLite.Scaffolder.Example
{
    public partial class DevForm : Form
    {
        public DevForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UniversityDatabase database = new UniversityDatabase("UniversityDatabase");
            database.CreateNewFile();

        }
        
        private void button2_Click(object sender, EventArgs e)
        {      
            UniversityDatabase database = new UniversityDatabase("UniversityDatabase");

        }
    }
}
