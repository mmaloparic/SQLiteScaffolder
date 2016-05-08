using SQLite.Scaffolder.Example.SimpleDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Example.SimpleDatabase
{
    public class UniversityDatabase : SQLiteDatabase
    {
        public UniversityDatabase(string databaseName) : base(databaseName)
        {
            Lectures = new SQLiteTable<Lecture>(this);
            Professors = new SQLiteTable<Professor>(this);
            Students = new SQLiteTable<Student>(this);
        }
        
        public SQLiteTable<Lecture> Lectures { get; set; }

        public SQLiteTable<Professor> Professors { get; set; }

        public SQLiteTable<Student> Students { get; set; }

        public SQLiteTable<StudentLecture> StudentLecture { get; set; }
        
    }
}
