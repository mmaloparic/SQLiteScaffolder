using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Components
{
    internal class ForeginKeyDefinition
    {
        internal TableDefinition TableBeingLinkedTo { get; set; }

        internal Dictionary<ColumnDefinition, ColumnDefinition> ForeginKeyToPrimaryKeyLinks { get; set; }
    }
}
