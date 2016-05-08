using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Exceptions
{
    public class ContainsSpacesException : Exception
    {
        public ContainsSpacesException(string message) : base(message)
        {

        }
    }
}
