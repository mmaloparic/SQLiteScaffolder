using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Tests.Components
{
    public class TestDatabase : SQLiteDatabase
    {
        public TestDatabase(string databaseName) : base(databaseName)
        {
            TestTable = new SQLiteTable<TestEntity>(this);
        }
        
        public SQLiteTable<TestEntity> TestTable { get; set; }
    }
}
