using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder
{
    public abstract class SQLiteEntity
    {
        internal Guid SQLiteObjectId { get; set; }
    }
}
