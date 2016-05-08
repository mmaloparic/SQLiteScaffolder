using SQLite.Scaffolder.Exceptions;
using System;

namespace SQLite.Scaffolder
{
    /// <summary>
    /// Represents a table within a SQLite database
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SQLiteTableInfoAttribute : Attribute
    {
        /// <summary>
        /// Name of the table
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Marks a class as SQLite table
        /// </summary>
        /// <param name="name">Desired name for the table. Cannot have spaces</param>
        /// <exception cref="SQLite.Scaffolder.Exceptions.ContainsSpacesException">Throws exception in case you specify a name with spaces</exception>
        public SQLiteTableInfoAttribute(string name)
        {
            if(name.Trim().Contains(" "))
            {
                throw new ContainsSpacesException("SQLite table names cannot contain spaces.");
            }

            Name = name.Trim();
        }
    }
}
