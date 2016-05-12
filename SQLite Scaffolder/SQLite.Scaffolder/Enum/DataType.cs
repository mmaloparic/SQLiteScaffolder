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
        /// Use to store <see cref="System.String"/>, <see cref="System.Guid"/> or their <see cref="Nullable"/> versions
        /// </summary>
        Text,

        /// <summary>
        /// Use to store <see cref="System.Int32"/>, <see cref="System.Int16"/>,  <see cref="System.Int64"/> or their <see cref="Nullable"/> versions
        /// </summary>
        Integer,

        /// <summary>
        /// Use to store <see cref="System.Decimal"/>, <see cref="System.Single"/>, <see cref="System.Double"/> or their <see cref="Nullable"/> versions
        /// </summary>
        Real,

        /// <summary>
        /// Use to store <see cref="System.Boolean"/> or its <see cref="Nullable"/> version
        /// </summary>
        Boolean,

        /// <summary>
        /// Use to store <see cref="System.DateTime"/> or its <see cref="Nullable"/> version
        /// </summary>
        DateTime,

        /// <summary>
        /// Use to store <see cref="System.Byte"/> arrays or its <see cref="Nullable"/> version.
        /// Perfect for images or other files
        /// </summary>
        Blob
    }
}
