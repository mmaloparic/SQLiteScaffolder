using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder
{
    /// <summary>
    /// Data type for a column in SQLite table. 
    /// Please visit the <a href="http://www.tutorialspoint.com/sqlite/sqlite_data_types.htm">http://www.tutorialspoint.com/sqlite/sqlite_data_types.htm</a> for more details
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// Use to store <see cref="System.String"/> or <see cref="System.Guid"/>
        /// </summary>
        Text,

        /// <summary>
        /// Use to store <see cref="System.Int32"/>, <see cref="System.Int16"/> , or <see cref="System.Int64"/>
        /// </summary>
        Integer,

        /// <summary>
        /// Use to store <see cref="System.Decimal"/>, <see cref="System.Single"/> or <see cref="System.Double"/>
        /// </summary>
        Real,

        /// <summary>
        /// Use to store <see cref="System.Boolean"/>
        /// </summary>
        Boolean,

        /// <summary>
        /// Use to store <see cref="System.DateTime"/>
        /// </summary>
        DateTime,

        /// <summary>
        /// Use to store <see cref="System.Byt]"/> arrays. Perfect for images or other files
        /// </summary>
        Blob
    }
}
