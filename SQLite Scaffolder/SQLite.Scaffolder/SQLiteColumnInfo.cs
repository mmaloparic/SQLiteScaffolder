using SQLite.Scaffolder;
using SQLite.Scaffolder.Exceptions;
using System;

namespace SQLite.Scaffolder
{
    /// <summary>
    /// Represents a column within a SQLite table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]    
    public class SQLiteColumnInfo : Attribute
    {
        //PROPERTIES
        /// <summary>
        /// Gets the column name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the flag which determines if the column is unique or not
        /// </summary>
        public Unique IsUnique { get; private set; }

        /// <summary>
        /// Gets the flag that determines if the column is a primary key or not
        /// </summary>
        public PrimaryKey IsPrimaryKey { get; private set; }

        /// <summary>
        /// Gets the data type stored within this column
        /// </summary>
        public DataType DataType { get; private set; }

        /// <summary>
        /// Gets the flag that determines if the data in this column is nullable
        /// </summary>
        public Nullable IsNullable { get; private set; }

        //CONSTRUCTOR
        /// <summary>
        /// Marks a property as a column within a table. 
        /// You must specify a desired column name. 
        /// You can optionaly mark the column as a primary key and/or unique.
        /// </summary>
        /// <param name="name">Desired name of the column. Cannot contain spaces</param>
        /// <param name="dataType">Type of data that you want to be stored in this specific SQLite column. Find the best match for your property</param>
        /// <param name="isUnique">Optional. Defaults to "No". Set to "Yes" if you want to impose a unique constraint on the column</param>
        /// <param name="isPrimaryKey">Optional. Defaults to "No". Set to "Yes" if you want to makr this column as containing a primary key. You can mark several columns to create a composite key.</param>
        /// <param name="isNullable">Optional. Defaults to "No". Set to "Yes" if you want to data stored in this column to be nullable.</param>
        public SQLiteColumnInfo(string name, DataType dataType, Unique isUnique = Unique.No, PrimaryKey isPrimaryKey = PrimaryKey.No, Nullable isNullable = Nullable.No)
        {
            if (name.Trim().Contains(" "))
            {
                throw new ContainsSpacesException("SQLite table names cannot contain spaces.");
            }

            Name = name.Trim();
            DataType = dataType;
            IsUnique = isUnique;
            IsPrimaryKey = isPrimaryKey;
            IsNullable = isNullable;
        }
    }
}
