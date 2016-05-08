using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Exceptions
{
    class MultipleTablesWithSameNameException : Exception
    {
        public MultipleTablesWithSameNameException(string message) : base(message) { }
    }
}
