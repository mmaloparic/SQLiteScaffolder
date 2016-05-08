using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder
{
    /// <summary>
    /// Represents a report for a query being executed on the SQLite database
    /// </summary>
    public class SQLiteOperationReport
    {
        /// <summary>
        /// Gets the field that describes if the operation you requested was a success or not
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// Gets the list of errors that have occured during the exectuion of the operation you requested
        /// </summary>
        public List<string> Errors { get; internal set; }

        /// <summary>
        /// Gets the message that describes the end result of the operation you requested.
        /// </summary>
        public string Message { get; internal set; }
    }
}
