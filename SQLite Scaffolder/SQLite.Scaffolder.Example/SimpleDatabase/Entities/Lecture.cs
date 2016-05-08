using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Scaffolder;

namespace SQLite.Scaffolder.Example.SimpleDatabase.Entities
{
    [SQLiteTableInfo("Lecture")]
    public class Lecture : SQLiteEntity
    {
        [SQLiteColumnInfo("ID", DataType.Text ,Unique.Yes, PrimaryKey.Yes)]
        public Guid ID { get; set; }

        [SQLiteColumnInfo("Name", DataType.Text)]
        public string Name { get; set; }

        [SQLiteColumnInfo("Description", DataType.Text)]
        public string Description { get; set; }

        [SQLiteColumnInfo("Image", DataType.Blob)]
        public byte[] ImageBytes { get; set; }
    }
}
