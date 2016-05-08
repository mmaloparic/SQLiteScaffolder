using SQLite.Scaffolder.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SQLite.Scaffolder.Components;

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
