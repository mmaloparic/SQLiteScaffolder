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
            Students = new SQLiteTable<Student>(this);
            StudentLecture = new SQLiteTable<StudentLecture>(this);        
        }
        
        public SQLiteTable<Lecture> Lectures { get; set; }

        public SQLiteTable<Student> Students { get; set; }

        public SQLiteTable<StudentLecture> StudentLecture { get; set; }
        
    }
}
