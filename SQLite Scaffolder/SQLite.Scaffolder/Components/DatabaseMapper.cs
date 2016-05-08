using SQLite.Scaffolder;
using SQLite.Scaffolder.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Components
{
    internal class DatabaseMapper
    {
        /// <summary>
        /// Uses reflection to analyze the SQLite database object and generates a matching <see cref="SQLite.Scaffolder.Components.DatabaseDefinition"/>
        /// </summary>    
        internal DatabaseDefinition MapDatabase(SQLiteDatabase databaseObject)
        {
            DatabaseDefinition databaseDefinition = new DatabaseDefinition();
            databaseDefinition.Name = databaseObject.Name;
            databaseDefinition.UserDefinedClass = databaseObject.GetType();
            databaseDefinition.Tables = new List<TableDefinition>();

            //get all properties of the table object that are designed by the user as SQLite tables
            List<PropertyInfo> sqliteTableProperties = databaseObject.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType)
                .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(SQLiteTable<>))
                .ToList();

            foreach (PropertyInfo sqliteTableProperty in sqliteTableProperties)
            {
                //get the user-made class that describes the SQLite entity that is supposed to be stored in the
                var propertyType = sqliteTableProperty.PropertyType;
                Type entityType = propertyType.GetGenericArguments().FirstOrDefault();
                if (entityType != null)
                {
                    TableDefinition nextTable = new TableDefinition();
                    nextTable.UserDefinedClass = entityType;
                    nextTable.Columns = new List<ColumnDefinition>();
                    nextTable.ForeginKeys = new List<ForeginKeyDefinition>();
                    
                    //get the table data (name) that is stored in the SQLiteTableInfoAttribute
                    SQLiteTableInfoAttribute tableInfoAttribute = entityType
                        .GetCustomAttributes()
                        .Where(a => a.GetType() == typeof(SQLiteTableInfoAttribute))
                        .FirstOrDefault() as SQLiteTableInfoAttribute;

                    if (tableInfoAttribute != null)
                    {
                        nextTable.Name = tableInfoAttribute.Name;
                    }
                    else
                    {
                        throw new MissingAttributeException(string.Format("A class you defined ({0}) as an entity for a SQLiteTable is missing a SQLiteTableInfo attribute", entityType.Name));
                    }

                    //get the columns definitions by inspecting all the properties that the user defined and marked with SQLiteColumnInfo attribute
                    List<PropertyInfo> entityTypeProperties = entityType.GetProperties()
                        .Where(p => p.GetCustomAttributes<SQLiteColumnInfo>().Any())
                        .ToList();

                    //map the columns
                    foreach (var columnProperty in entityTypeProperties)
                    {
                        ColumnDefinition nextColumn = new ColumnDefinition();
                        nextColumn.UserDefinedClass = columnProperty.PropertyType;

                        //get the attribute values
                        SQLiteColumnInfo columnInfoAttribute = columnProperty.GetCustomAttributes()
                        .Where(a => a.GetType() == typeof(SQLiteColumnInfo))
                        .FirstOrDefault() as SQLiteColumnInfo;

                        //copy the data to column definition and add it to the table
                        nextColumn.Name = columnInfoAttribute.Name;
                        nextColumn.Type = columnInfoAttribute.DataType;
                        nextColumn.IsNullable = columnInfoAttribute.IsNullable;
                        nextColumn.IsPrimaryKey = columnInfoAttribute.IsPrimaryKey;
                        nextColumn.IsUnique = columnInfoAttribute.IsUnique;

                        nextTable.Columns.Add(nextColumn);
                    }

                    //add the table definition to the database definition
                    databaseDefinition.Tables.Add(nextTable);
                }
            }

            return databaseDefinition;
        }
    }
}
