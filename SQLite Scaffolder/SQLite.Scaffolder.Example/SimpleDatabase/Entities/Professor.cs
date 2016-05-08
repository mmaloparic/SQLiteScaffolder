using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Scaffolder;

namespace SQLite.Scaffolder.Example.SimpleDatabase.Entities
{
    [SQLiteTableInfo("Professor")]
    public class Professor : SQLiteEntity
    {
        public Professor(SQLiteDatabase database) : base(database) { }

        [SQLiteColumnInfo("ID", DataType.Text, Unique.Yes, PrimaryKey.Yes)]
        public Guid ID { get; set; }

        [SQLiteColumnInfo("Name", DataType.Text)]
        public string Name { get; set; }

        [SQLiteColumnInfo("LectureID", DataType.Text)]
        public Guid LectureId { get; set; }
    }
}
