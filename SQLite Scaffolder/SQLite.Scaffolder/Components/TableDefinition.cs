using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Components
{
    internal class TableDefinition
    {
        internal string Name { get; set; }

        internal List<ColumnDefinition> Columns { get; set; }

        internal List<ForeginKeyDefinition> ForeginKeys { get; set; }

        internal Type UserDefinedClass { get; set; }

        internal TableDefinition()
        {
            Columns = new List<ColumnDefinition>();
            ForeginKeys = new List<ForeginKeyDefinition>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
