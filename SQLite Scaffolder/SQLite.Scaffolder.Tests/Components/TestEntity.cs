using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Tests.Components
{
    [SQLiteTableInfo("Test")]
    public class TestEntity : SQLiteEntity
    {
        [SQLiteColumnInfo("IdColumn", DataType.Text, Unique.Yes, PrimaryKey.Yes, Nullable.No)]
        public Guid ID { get; set; }

        [SQLiteColumnInfo("NumberColumn", DataType.Integer)]
        public int NumberProperty { get; set; }

        [SQLiteColumnInfo("TextColumn", DataType.Text)]
        public string TextProperty { get; set; }

        [SQLiteColumnInfo("DecimalColumn", DataType.Real)]
        public decimal DecimalProperty { get; set; }

        [SQLiteColumnInfo("DateColumn", DataType.DateTime)]
        public DateTime DateProperty { get; set; }

        [SQLiteColumnInfo("ImageColumn", DataType.Blob, Unique.No, PrimaryKey.No, Nullable.Yes)]
        public byte[] ImageBytesProperty { get; set; }
    }
}
