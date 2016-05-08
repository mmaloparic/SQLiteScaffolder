using SQLite.Scaffolder.Example.SimpleDatabase;
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
            var response = database.SendQueryGetResponse(new System.Data.SQLite.SQLiteCommand("SELECT name FROM my_db.sqlite_master WHERE type='table';"));
        }
    }
}
