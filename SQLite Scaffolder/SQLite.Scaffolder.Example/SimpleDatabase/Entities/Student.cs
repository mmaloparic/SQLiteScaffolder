﻿using SQLite.Scaffolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Example.SimpleDatabase.Entities
{
    [SQLiteTableInfo("Student")]
    public class Student : SQLiteEntity
    {
        public Student(SQLiteDatabase database) : base(database)
        {
        }

        [SQLiteColumnInfo("ID", DataType.Text, Unique.Yes, PrimaryKey.Yes)]
        public Guid ID { get; set; }

        [SQLiteColumnInfo("Name", DataType.Text)]
        public string Name { get; set; }

        [SQLiteColumnInfo("Lastname", DataType.Text)]
        public string Lastname { get; set; }

        [SQLiteColumnInfo("Birthday", DataType.DateTime)]
        public DateTime Birthday { get; set; }
        
    }
}