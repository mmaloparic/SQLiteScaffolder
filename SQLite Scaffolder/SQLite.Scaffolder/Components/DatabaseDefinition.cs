using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Components
{
    internal class DatabaseDefinition
    {
        internal string Name { get; set; }

        internal List<TableDefinition> Tables { get; set; }

        internal Type UserDefinedClass { get; set; }

        public DatabaseDefinition()
        {
            Tables = new List<TableDefinition>();
        }
    }
}
