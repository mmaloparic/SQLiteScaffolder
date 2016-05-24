using SQLite.Scaffolder.Example.Properties;
using SQLite.Scaffolder.Example.SimpleDatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Example.Repositories
{
    public abstract class BaseRepository
    {
        public UniversityDatabase Database { get; set; }

        public BaseRepository()
        {
            Database = new UniversityDatabase(Settings.Default.DatabaseName);
            string databaseFilePath = string.Format("{0}\\{1}.sqlite", Environment.CurrentDirectory, Database.Name);
            if (!File.Exists(databaseFilePath))
            {
                Database.CreateNewFile();
            }
        }
    }
}
