using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder
{
    public abstract class SQLiteEntity
    {
        SQLiteDatabase database;

        public SQLiteEntity(SQLiteDatabase database)
        {

        }
    }
}
