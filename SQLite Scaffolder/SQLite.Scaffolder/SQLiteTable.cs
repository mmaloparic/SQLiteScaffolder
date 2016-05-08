using SQLite.Scaffolder.Components;
using SQLite.Scaffolder.SQL;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
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
                SQLGenerator sqlGenerator = new SQLGenerator();
                SQLiteCommand insertEntitySQL = sqlGenerator.GenerateInsertCommand<T>(Database.DatabaseDefinition, entity);
                Database.SendQueryNoResponse(insertEntitySQL);
                report.IsSuccess = true;
                report.Message = string.Format("'{0}' was inserted with success", entity.GetType().Name);
                report.Errors = new List<string>();
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
                    }         
                    catch(Exception ex)
                    {
                        report.Errors.Add(ex.Message + " | Stacktrace: " + ex.StackTrace);
                    }                                     
                }

                Database.SendQueryNoResponse(new SQLiteCommand("END TRANSACTION"), true);
                Database.CloseConnection();

                report.IsSuccess = true;
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

        public IEnumerable<T> GetAll()
        {
            List<T> resultsList = new List<T>();

            SQLGenerator sqlGenerator = new SQLGenerator();
            SQLiteCommand sqlSelectQuery = sqlGenerator.GenerateSelectAllCommand<T>(Database.DatabaseDefinition);
            TableDefinition matchingTable = Database.DatabaseDefinition.Tables.First(t => t.UserDefinedClass == typeof(T));

            var dataReader = Database.SendQueryGetResponse(sqlSelectQuery);

            if(dataReader != null)
            {
                while (dataReader.Read())
                {
                    T nextEntity = new T();

                    foreach(ColumnDefinition nextColumn in matchingTable.Columns)
                    {
                        int columnIndex = dataReader.GetOrdinal(nextColumn.Name);


                        //switch(nextColumn.Type)
                        //{
                        //    case DataType.Text:
                        //        {
                        //            if(typeof(nextColumn.UserDefinedClass) == 
                        //            break;
                        //        }
                        //}
                    }
                }
            }            

            return resultsList;
        }   
    }
}
