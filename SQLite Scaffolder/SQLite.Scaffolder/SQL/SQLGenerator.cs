using SQLite.Scaffolder.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SQLite.Scaffolder.Components;
using SQLite.Scaffolder.Properties;

namespace SQLite.Scaffolder.SQL
{
    internal class SQLGenerator : ISQLGenerator
    {
        /// <summary>
        /// Uses reflection to analyze the SQLite database object and generates SQL to create a matching database
        /// </summary>    
        internal SQLiteCommand CreateDatabase(DatabaseDefinition databaseDefinition)
        {
            StringBuilder sb = new StringBuilder();

            foreach (TableDefinition nextTable in databaseDefinition.Tables)
            {
                string nextTableSql = GenerateTableCreationSQL(nextTable);
                sb.Append(nextTableSql);
            }

            string sql = sb.ToString();
            return new SQLiteCommand(sql);
        }

        /// <summary>
        /// Analyzes the entity passed in, its place in the database and generates SQL for inserting it in to the database
        /// </summary>
        /// <typeparam name="T">Type that you are inserting in to the database. Must inherit from <see cref="SQLiteEntity"/></typeparam>
        /// <param name="databaseDefinition">Database definition from which to extract data about the entity being inserted</param>
        /// <param name="entity">Entity that you want to insert</param>
        /// <returns>Returns a <see cref="SQLiteCommand"/> object that contains the insert query</returns>
        internal SQLiteCommand GenerateInsertCommand<T>(DatabaseDefinition databaseDefinition, T entity) where T : SQLiteEntity
        {
            //find the entity table definition from the database definition
            TableDefinition matchingTable = databaseDefinition.Tables.First(t => t.UserDefinedClass == typeof(T));

            string columnsList = string.Empty;
            string valuesPlaceholderList = string.Empty;
            List<SQLiteParameter> parameterValuesList = new List<SQLiteParameter>();
            int parameterIndex = 0;

            foreach (var column in matchingTable.Columns)
            {
                columnsList += column.Name + ",";

                //get the value for this column
                PropertyInfo propertyInfo = entity.GetType().GetProperties().First(p => p.GetCustomAttribute<SQLiteColumnInfo>().Name == column.Name);
                if(propertyInfo != null)
                {
                    Type propertyType = propertyInfo.PropertyType;
                    bool added = false;

                    switch(column.Type)
                    {
                        case DataType.Integer:
                            {
                                if (propertyType == typeof(int) || propertyType == typeof(int?))
                                {
                                    string parameterNamePlaceholder = string.Format("@parameter{0}", parameterIndex);
                                    valuesPlaceholderList += parameterNamePlaceholder + ",";
                                    parameterIndex++;

                                    SQLiteParameter nextParameter = new SQLiteParameter(parameterNamePlaceholder, System.Data.DbType.Int32);
                                    nextParameter.Value = propertyInfo.GetValue(entity);
                                    parameterValuesList.Add(nextParameter);

                                    added = true;
                                    continue;
                                }

                                if (propertyType == typeof(long) || propertyType == typeof(long?))
                                {
                                    string parameterNamePlaceholder = string.Format("@parameter{0}", parameterIndex);
                                    valuesPlaceholderList += parameterNamePlaceholder + ",";
                                    parameterIndex++;

                                    SQLiteParameter nextParameter = new SQLiteParameter(parameterNamePlaceholder, System.Data.DbType.Int64);
                                    nextParameter.Value = propertyInfo.GetValue(entity);
                                    parameterValuesList.Add(nextParameter);

                                    added = true;
                                    continue;
                                }

                                if (propertyType == typeof(short) || propertyType == typeof(short?))
                                {
                                    string parameterNamePlaceholder = string.Format("@parameter{0}", parameterIndex);
                                    valuesPlaceholderList += parameterNamePlaceholder + ",";
                                    parameterIndex++;

                                    SQLiteParameter nextParameter = new SQLiteParameter(parameterNamePlaceholder, System.Data.DbType.Int16);
                                    nextParameter.Value = propertyInfo.GetValue(entity);
                                    parameterValuesList.Add(nextParameter);

                                    added = true;
                                    continue;
                                }
                                break;
                            }

                        case DataType.Real:
                            {
                                if (propertyType == typeof(decimal) || propertyType == typeof(decimal?))
                                {
                                    string parameterNamePlaceholder = string.Format("@parameter{0}", parameterIndex);
                                    valuesPlaceholderList += parameterNamePlaceholder + ",";
                                    parameterIndex++;

                                    SQLiteParameter nextParameter = new SQLiteParameter(parameterNamePlaceholder, System.Data.DbType.Decimal);
                                    nextParameter.Value = propertyInfo.GetValue(entity);
                                    parameterValuesList.Add(nextParameter);

                                    added = true;
                                    continue;
                                }

                                if (propertyType == typeof(float) || propertyType == typeof(float?))
                                {
                                    string parameterNamePlaceholder = string.Format("@parameter{0}", parameterIndex);
                                    valuesPlaceholderList += parameterNamePlaceholder + ",";
                                    parameterIndex++;

                                    SQLiteParameter nextParameter = new SQLiteParameter(parameterNamePlaceholder, System.Data.DbType.Single);
                                    nextParameter.Value = propertyInfo.GetValue(entity);
                                    parameterValuesList.Add(nextParameter);

                                    added = true;
                                    continue;
                                }

                                if (propertyType == typeof(double) || propertyType == typeof(double?))
                                {
                                    string parameterNamePlaceholder = string.Format("@parameter{0}", parameterIndex);
                                    valuesPlaceholderList += parameterNamePlaceholder + ",";
                                    parameterIndex++;

                                    SQLiteParameter nextParameter = new SQLiteParameter(parameterNamePlaceholder, System.Data.DbType.Double);
                                    nextParameter.Value = propertyInfo.GetValue(entity);
                                    parameterValuesList.Add(nextParameter);

                                    added = true;
                                    continue;
                                }
                                break;
                            }

                        case DataType.Text:
                            {
                                if (propertyType == typeof(string))
                                {
                                    string parameterNamePlaceholder = string.Format("@parameter{0}", parameterIndex);
                                    valuesPlaceholderList += parameterNamePlaceholder + ",";
                                    parameterIndex++;

                                    SQLiteParameter nextParameter = new SQLiteParameter(parameterNamePlaceholder, System.Data.DbType.String);
                                    nextParameter.Value = propertyInfo.GetValue(entity);
                                    parameterValuesList.Add(nextParameter);

                                    added = true;
                                    continue;
                                }

                                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                                {
                                    string parameterNamePlaceholder = string.Format("@parameter{0}", parameterIndex);
                                    valuesPlaceholderList += parameterNamePlaceholder + ",";
                                    parameterIndex++;

                                    //use string even if Guid exists because SQLite engine seems to mumble up and destroy a GUID, but storing it as a string keeps it intact
                                    SQLiteParameter nextParameter = new SQLiteParameter(parameterNamePlaceholder, System.Data.DbType.String); 
                                    nextParameter.Value = propertyInfo.GetValue(entity);
                                    parameterValuesList.Add(nextParameter);

                                    added = true;
                                    continue;
                                }

                                break;
                            }

                        case DataType.DateTime:
                            {
                                if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
                                {
                                    string parameterNamePlaceholder = string.Format("@parameter{0}", parameterIndex);
                                    valuesPlaceholderList += parameterNamePlaceholder + ",";
                                    parameterIndex++;

                                    SQLiteParameter nextParameter = new SQLiteParameter(parameterNamePlaceholder, System.Data.DbType.DateTime);
                                    nextParameter.Value = propertyInfo.GetValue(entity);
                                    parameterValuesList.Add(nextParameter);

                                    added = true;
                                    continue;
                                }

                                break;
                            }

                        case DataType.Boolean:
                            {
                                if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                                {
                                    string parameterNamePlaceholder = string.Format("@parameter{0}", parameterIndex);
                                    valuesPlaceholderList += parameterNamePlaceholder + ",";
                                    parameterIndex++;

                                    SQLiteParameter nextParameter = new SQLiteParameter(parameterNamePlaceholder, System.Data.DbType.Boolean);
                                    nextParameter.Value = propertyInfo.GetValue(entity);
                                    parameterValuesList.Add(nextParameter);

                                    added = true;
                                    continue;
                                }

                                break;
                            }                        

                        case DataType.Blob:
                            {
                                if (propertyType == typeof(byte[]))
                                {
                                    string blobParameterPlaceholder = string.Format("@binaryParameter{0}", parameterIndex);
                                    valuesPlaceholderList += blobParameterPlaceholder + ",";
                                    parameterIndex++;

                                    SQLiteParameter nextBlobParameter = new SQLiteParameter(blobParameterPlaceholder, System.Data.DbType.Binary);
                                    nextBlobParameter.Value = propertyInfo.GetValue(entity);
                                    parameterValuesList.Add(nextBlobParameter);

                                    added = true;
                                    continue;
                                }
                                break;
                            }
                        default:
                            {
                                throw new NotSupportedException(string.Format("Data type you specified for the property matching the column '{0}' in table '{1}' is not supported by SQLiteScaffolder", column.Name, matchingTable.Name));
                            }

                    }

                    //check if the parameter was added
                    if(!added)
                    {
                        throw new NotSupportedException(string.Format("Data type you specified for the property matching the column '{0}' in table '{1}' is not supported by SQLiteScaffolder", column.Name, matchingTable.Name));
                    }  
                }
            }

            columnsList = columnsList.TrimEnd(',');
            valuesPlaceholderList = valuesPlaceholderList.TrimEnd(',');            

            //create the SQL query
            string insertQuery = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", matchingTable.Name, columnsList, valuesPlaceholderList);

            //create the insert command and add all the parameters we generated
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery);

            foreach(var parameter in parameterValuesList)
            {
                insertCommand.Parameters.Add(parameter);
            }

            return insertCommand;
        }

        /// <summary>
        /// Generates a SQL query that will select all entities of the specified type
        /// </summary>
        /// <typeparam name="T">Entity that you want to retrieve</typeparam>
        /// <param name="databaseDefinition">Database definition from which to extract data about the entity being retrieved</param>
        /// <returns></returns>
        internal SQLiteCommand GenerateSelectAllCommand<T>(DatabaseDefinition databaseDefinition, string whereCondition, string orderbyParameterName, bool descending)
        {
            //find the entity table definition from the database definition
            TableDefinition matchingTable = databaseDefinition.Tables.First(t => t.UserDefinedClass == typeof(T));

            string sql = string.Format("SELECT * FROM {0}", matchingTable.Name);

            if(!string.IsNullOrEmpty(whereCondition))
            {
                sql += string.Format(" WHERE {0}", whereCondition);
            }

            if(!string.IsNullOrEmpty(orderbyParameterName))
            {
                sql += string.Format(" ORDER BY {0} {1}", orderbyParameterName, descending ? "DESC" : "ASC");
            }
            
            return new SQLiteCommand(sql);
        }

        internal SQLiteCommand GenerateUpdateCommand<T>(DatabaseDefinition databaseDefinition, T entity)
        {
            //find the entity table definition from the database definition
            TableDefinition matchingTable = databaseDefinition.Tables.First(t => t.UserDefinedClass == typeof(T));

            //string sql = string.Format("UPDATE {0} SET {1} WHERE {2}", )

            throw new NotImplementedException();
        }


        //PRIVATE METHODS
        private string GenerateTableCreationSQL(TableDefinition table)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ColumnDefinition nextColumn in table.Columns)
            {
                string sqlForCreatingTheColumn = GenerateColumnCreationSQL(nextColumn);
                sb.Append(sqlForCreatingTheColumn);
            }

            string sqlForCreatingColumns = sb.ToString().TrimEnd(',');
            string sql = string.Format("CREATE TABLE {0} ({1});", table.Name, sqlForCreatingColumns);
            
            return sql;
        }        

        private string GenerateColumnCreationSQL(ColumnDefinition nextColumn)
        {
            string dataType = GetColumnType(nextColumn.Type);
            string isNull = nextColumn.IsNullable == Nullable.Yes ? "NULL" : "NOT NULL";
            string isPrimaryKey = nextColumn.IsPrimaryKey == PrimaryKey.Yes ? "PRIMARY KEY" : string.Empty;
            string isUnique = nextColumn.IsUnique == Unique.Yes ? "UNIQUE" : string.Empty;

            string sql = string.Format("{0} {1} {2} {3},", nextColumn.Name, dataType, isPrimaryKey, isNull);

            return sql;
        }

        private string GetColumnType(DataType type)
        {
            string dataType = string.Empty;
            switch (type)
            {
                case DataType.Blob:
                    {
                        dataType = "BLOB";
                        break;
                    }
                case DataType.Boolean:
                    {
                        dataType = "BOOLEAN";
                        break;
                    }
                case DataType.DateTime:
                    {
                        dataType = "TEXT";
                        break;
                    }
                case DataType.Integer:
                    {
                        dataType = "INT";
                        break;
                    }
                case DataType.Real:
                    {
                        dataType = "REAL";
                        break;
                    }
                case DataType.Text:
                    {
                        dataType = "TEXT";
                        break;
                    }
            }

            return dataType;
        }

        
    }
}
