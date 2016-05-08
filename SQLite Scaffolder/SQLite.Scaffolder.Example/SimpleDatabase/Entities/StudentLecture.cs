using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Example.SimpleDatabase.Entities
{
    [SQLiteTableInfo("StudentLecture")]
    public class StudentLecture : SQLiteEntity
    {
        [SQLiteColumnInfo("StudentId", DataType.Text)]
        public Guid StudentId { get; set; }

        [SQLiteColumnInfo("LectureId", DataType.Text, Unique.No, PrimaryKey.Yes)]
        public Guid LectureId { get; set; }
    }
}
