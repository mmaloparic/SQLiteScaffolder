﻿using SQLite.Scaffolder.Components;
using SQLite.Scaffolder.SQL;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder
{
    public class SQLiteTable<T> where T : SQLiteEntity, new()
    {
        private SQLiteDatabase Database;

        /// <summary>
        /// Creates a new instance of the <see cref="SQLite.Scaffolder.SQLiteDatabase"/> class.
        /// </summary>
        /// <param name="database">Pass in the database that this table will be part of </param>
        /// <example><code>SQLiteTable Customers = new SQLiteTable(this);</code></example>
        public SQLiteTable(SQLiteDatabase database)
        {
            Database = database;
        }

        /// <summary>
        /// Inserts a new entity in to the SQLite database
        /// </summary>
        /// <param name="entity">Entity that you want to insert</param>
        public SQLiteOperationReport Insert(T entity)
        {
            SQLiteOperationReport report = new SQLiteOperationReport();

            if (entity != null)
            {
                try
                {
                    SQLGenerator sqlGenerator = new SQLGenerator();
                    SQLiteCommand insertEntitySQL = sqlGenerator.GenerateInsertCommand<T>(Database.DatabaseDefinition, entity);
                    Database.SendQueryNoResponse(insertEntitySQL);
                    report.IsSuccess = true;
                    report.Message = string.Format("'{0}' was inserted with success", entity.GetType().Name);
                    report.Errors = new List<string>();
                }
                catch(Exception ex)
                {
                    report.Errors.Add(ex.Message);
                    report.Errors.Add(ex.StackTrace);
                }
                
            }
            else
            {
                report.IsSuccess = false;
                report.Message = string.Format("Entity you specified was null. Operation aborted", entity.GetType().Name);
                report.Errors = new List<string>() { "Entity you passed in as parameter was null. There was nothing to insert." };
            }

            return report;
        }

        /// <summary>
        /// Inserts a multiple entities in to the SQLite database by opening a transaction and closing it after finishing the work.
        /// </summary>
        /// <param name="entity">List of entities that you want to insert</param>
        public SQLiteOperationReport InsertRange(List<T> entities)
        {
            SQLiteOperationReport report = new SQLiteOperationReport();
            report.Errors = new List<string>();

            if (entities != null)
            {
                SQLGenerator sqlGenerator = new SQLGenerator();
                Database.SendQueryNoResponse(new SQLiteCommand("BEGIN TRANSACTION"), true);

                foreach (var entity in entities)
                {
                    try
                    {
                        SQLiteCommand insertEntitySQL = sqlGenerator.GenerateInsertCommand<T>(Database.DatabaseDefinition, entity);
                        Database.SendQueryNoResponse(insertEntitySQL, true);
                        report.IsSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        report.IsSuccess = false;
                        report.Errors.Add(ex.Message);
                        report.Errors.Add(ex.StackTrace);
                    }
                }

                Database.SendQueryNoResponse(new SQLiteCommand("END TRANSACTION"), true);
                Database.CloseConnection();

                report.Message = report.Errors.Any() ? "Operation completed with some errors" : "Operation completed";
            }
            else
            {
                report.IsSuccess = false;
                report.Message = "List you specified was null. Operation aborted";
                report.Errors = new List<string>() { "Entity you passed in as parameter was null. There was nothing to insert." };
            }

            return report;
        }

        /// <summary>
        /// Selects all entities of specified type from the database. 
        /// You can optionaly add a "where" condition to qualify only specific objects from the database.
        /// Additional, you can plug in the optional parameter for "order by" clause, which will sort the entites before returning them.
        /// </summary>
        /// <param name="whereCondition">
        /// Optional parameter. Qualifies only those object in the database that match the specified condition.
        /// For example, "ID = 10" would be resolved as 'WHERE ID = 10' and would only return that object whose value in the ID column is equal to 10
        /// </param>
        /// <param name="orderByCondition">Optional parameter. Orders the queried objects according to your condition. 
        /// For example, typing in "Age" would be resolve to "ORDER BY Age" in the database, which would order the queried objects by the value in their Age column
        /// </param>
        /// <param name="descending">Optional parameter. If set to true, queried objects will be order in a descending order. If set to false, they will be ordered in ascending order.</param>
        /// <returns></returns>
        public IEnumerable<T> SelectAll(string whereCondition = "", string orderByCondition = "", bool descending = false)
        {
            List<T> resultsList = new List<T>();

            //generate the SELECT command
            SQLGenerator sqlGenerator = new SQLGenerator();
            SQLiteCommand sqlSelectQuery = sqlGenerator.GenerateSelectAllCommand<T>(Database.DatabaseDefinition, whereCondition, orderByCondition, descending);

            //get the table definition from the database definition map
            TableDefinition matchingTable = Database.DatabaseDefinition.Tables.First(t => t.UserDefinedClass == typeof(T));

            //send the query to the database and get the response
            var dataReader = Database.SendQueryGetResponse(sqlSelectQuery);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    //create a new instance of the user-defined entity...
                    T nextEntity = new T();

                    //first get the SQLiteObject identifier ID, so we can track the this specific object
                    nextEntity.SQLiteObjectId = new Guid((string)dataReader[SQLConstants.SQLiteObjectIdColumnName]);

                    //...and populate it's properties by finding them according their name, which we know is unique because of the constraints
                    foreach (ColumnDefinition nextColumn in matchingTable.Columns)
                    {
                        //first find the index of the property 
                        int columnIndex = dataReader.GetOrdinal(nextColumn.Name);

                        //get the property with the matching name
                        PropertyInfo matchingProperty = nextEntity.GetType().GetProperties().First(p => p.GetCustomAttribute<SQLiteColumnInfo>().Name == nextColumn.Name);
                        var matchingValue = dataReader[columnIndex];

                        //switch through the property types
                        switch (nextColumn.Type)
                        {
                            case DataType.Integer:
                                {
                                    //int
                                    if (matchingProperty.PropertyType == typeof(int) && matchingValue != null)
                                    {
                                        matchingProperty.SetValue(nextEntity, (int)matchingValue);
                                        continue;
                                    }

                                    //nullable<int>
                                    if (matchingProperty.PropertyType == typeof(int?))
                                    {
                                        if (matchingValue == null)
                                        {
                                            matchingProperty.SetValue(nextEntity, null);
                                            continue;
                                        }
                                        else
                                        {
                                            matchingProperty.SetValue(nextEntity, (int?)matchingValue);
                                            continue;
                                        }
                                    }

                                    //short
                                    if (matchingProperty.PropertyType == typeof(short) && matchingValue != null)
                                    {
                                        matchingProperty.SetValue(nextEntity, (short)matchingValue);
                                        continue;
                                    }

                                    //nullable<short>
                                    if (matchingProperty.PropertyType == typeof(short?))
                                    {
                                        if (matchingValue == null)
                                        {
                                            matchingProperty.SetValue(nextEntity, null);
                                            continue;
                                        }
                                        else
                                        {
                                            matchingProperty.SetValue(nextEntity, (short?)matchingValue);
                                            continue;
                                        }
                                    }

                                    //long
                                    if (matchingProperty.PropertyType == typeof(long) && matchingValue != null)
                                    {
                                        matchingProperty.SetValue(nextEntity, (long)matchingValue);
                                        continue;
                                    }

                                    //nullable<long>
                                    if (matchingProperty.PropertyType == typeof(long?))
                                    {
                                        if (matchingValue == null)
                                        {
                                            matchingProperty.SetValue(nextEntity, null);
                                            continue;
                                        }
                                        else
                                        {
                                            matchingProperty.SetValue(nextEntity, (long?)matchingValue);
                                            continue;
                                        }
                                    }

                                    continue;
                                }
                            case DataType.Real:
                                {
                                    //decimal
                                    if (matchingProperty.PropertyType == typeof(decimal) && matchingValue != null)
                                    {
                                        matchingProperty.SetValue(nextEntity, (decimal)matchingValue);
                                        continue;
                                    }

                                    //nullable<decimal>
                                    if (matchingProperty.PropertyType == typeof(decimal?))
                                    {
                                        if (matchingValue == null)
                                        {
                                            matchingProperty.SetValue(nextEntity, null);
                                            continue;
                                        }
                                        else
                                        {
                                            matchingProperty.SetValue(nextEntity, (decimal?)matchingValue);
                                            continue;
                                        }
                                    }

                                    //float
                                    if (matchingProperty.PropertyType == typeof(decimal) && matchingValue != null)
                                    {
                                        matchingProperty.SetValue(nextEntity, (decimal)matchingValue);
                                        continue;
                                    }

                                    //nullable<float>
                                    if (matchingProperty.PropertyType == typeof(float?))
                                    {
                                        if (matchingValue == null)
                                        {
                                            matchingProperty.SetValue(nextEntity, null);
                                            continue;
                                        }
                                        else
                                        {
                                            matchingProperty.SetValue(nextEntity, (float?)matchingValue);
                                            continue;
                                        }
                                    }

                                    //double
                                    if (matchingProperty.PropertyType == typeof(double) && matchingValue != null)
                                    {
                                        matchingProperty.SetValue(nextEntity, (double)matchingValue);
                                        continue;
                                    }

                                    //nullable<double>
                                    if (matchingProperty.PropertyType == typeof(double?))
                                    {
                                        if (matchingValue == null)
                                        {
                                            matchingProperty.SetValue(nextEntity, null);
                                            continue;
                                        }
                                        else
                                        {
                                            matchingProperty.SetValue(nextEntity, (double?)matchingValue);
                                            continue;
                                        }
                                    }
                                    continue;
                                }
                            case DataType.Text:
                                {
                                    //string
                                    if (matchingProperty.PropertyType == typeof(string) && matchingValue != null)
                                    {
                                        matchingProperty.SetValue(nextEntity, (string)matchingValue);
                                        continue;
                                    }

                                    //Guid
                                    if (matchingProperty.PropertyType == typeof(Guid) && matchingValue != null)
                                    {
                                        matchingProperty.SetValue(nextEntity, new Guid((string)matchingValue));
                                        continue;
                                    }

                                    //nullable<Guid>
                                    if (matchingProperty.PropertyType == typeof(Guid?))
                                    {
                                        if (matchingValue == null)
                                        {
                                            matchingProperty.SetValue(nextEntity, null);
                                            continue;
                                        }
                                        else
                                        {
                                            matchingProperty.SetValue(nextEntity, new Guid((string)matchingValue));
                                            continue;
                                        }
                                    }
                                    continue;
                                }
                            case DataType.Boolean:
                                {
                                    //bool
                                    if (matchingProperty.PropertyType == typeof(bool) && matchingValue != null)
                                    {
                                        matchingProperty.SetValue(nextEntity, (bool)matchingValue);
                                        continue;
                                    }

                                    //nullable<bool>
                                    if (matchingProperty.PropertyType == typeof(bool?))
                                    {
                                        if (matchingValue == null)
                                        {
                                            matchingProperty.SetValue(nextEntity, null);
                                            continue;
                                        }
                                        else
                                        {
                                            matchingProperty.SetValue(nextEntity, (bool?)matchingValue);
                                            continue;
                                        }
                                    }
                                    continue;
                                }
                            case DataType.DateTime:
                                {
                                    //DateTime
                                    if (matchingProperty.PropertyType == typeof(DateTime) && matchingValue != null)
                                    {
                                        matchingProperty.SetValue(nextEntity, (DateTime)matchingValue);
                                        continue;
                                    }

                                    //nullable<DateTime>
                                    if (matchingProperty.PropertyType == typeof(DateTime?))
                                    {
                                        if (matchingValue == null)
                                        {
                                            matchingProperty.SetValue(nextEntity, null);
                                            continue;
                                        }
                                        else
                                        {
                                            matchingProperty.SetValue(nextEntity, (DateTime?)matchingValue);
                                            continue;
                                        }
                                    }
                                    continue;
                                }
                            case DataType.Blob:
                                {
                                    //byte[]
                                    if (matchingProperty.PropertyType == typeof(byte[]) && matchingValue != null)
                                    {
                                        matchingProperty.SetValue(nextEntity, (byte[])matchingValue);
                                        continue;
                                    }
                                    continue;
                                }
                        }
                    }


                    resultsList.Add(nextEntity);
                }
            }

            return resultsList;
        }

        /// <summary>
        /// Updates the entity that that you plug in by finding it in the database via its primary key(s) and replacing the old values with the new ones.
        /// </summary>
        /// <param name="entity">Entity that you want to update. Values contained in this object will replace the values of the object that is currently in the database.
        /// Primary key(s) are used to find the object in the database, so that primary key(s) should be left intact. </param>
        /// <returns></returns>
        public SQLiteOperationReport Update(T entity)
        {
            SQLiteOperationReport report = new SQLiteOperationReport();
            report.Errors = new List<string>();

            if(entity != null)
            {
                SQLGenerator sqlGenerator = new SQLGenerator();
                try
                {
                    SQLiteCommand updateCommand = sqlGenerator.GenerateUpdateCommand(Database.DatabaseDefinition, entity);
                    Database.SendQueryNoResponse(updateCommand);
                    report.IsSuccess = true;
                    report.Message = "Operation completed.";
                }
                catch (Exception ex)
                {
                    report.IsSuccess = false;
                    report.Message = "Update failed. Please check the Errors list for details and stack trace.";
                    report.Errors.Add(ex.Message);
                    report.Errors.Add(ex.StackTrace);
                }
            }
            else
            {
                report.IsSuccess = false;
                report.Message = "Entity is null. Operation aborted";
                report.Errors.Add("Entity you specified was null. There was nothing to update. Operation aborted");
            }
            
            
            return report;

        }

        public SQLiteOperationReport Delete (T entity)
        {
            SQLiteOperationReport report = new SQLiteOperationReport();
            report.Errors = new List<string>();

            if(entity != null)
            {
                try
                {
                    SQLGenerator sqlGenerator = new SQLGenerator();
                    SQLiteCommand deleteCommand = sqlGenerator.GenerateDeleteCommand<T>(Database.DatabaseDefinition, entity);
                    Database.SendQueryNoResponse(deleteCommand);
                    report.IsSuccess = true;
                    report.Message = "Delete operation was a success";
                }
                catch(Exception ex)
                {
                    report.IsSuccess = false;
                    report.Message = "Errors occured while performing the delete operation. Check the Errors list for more details";
                    report.Errors.Add(ex.Message);
                    report.Errors.Add(ex.StackTrace);
                }
            }
            else
            {
                report.IsSuccess = false;
                report.Message = "Entity is null. There is nothing to delete. Operation aborted";
                report.Errors.Add("Entity you specified was null. There was nothing to delete. Operation aborted");
            }

            return report;
        }
    }
}
