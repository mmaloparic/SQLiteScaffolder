using SQLite.Scaffolder.Components;
using SQLite.Scaffolder.SQL;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder
{
    public abstract class SQLiteDatabase : IDisposable
    {
        //FIELDS
        internal SQLiteConnection SQLiteConnection = null;
        internal DatabaseDefinition DatabaseDefinition = null;
        private string _connectionString = "";


        //PROPERTIES
        /// <summary>
        /// Gets or sets the database name
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the database connection string
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                string oldValue = _connectionString;
                _connectionString = value;

                //check if the connection string value changed and update it if it did
                if(!string.IsNullOrEmpty(_connectionString) && oldValue != value)
                {
                    this.SQLiteConnection = new SQLiteConnection(ConnectionString);
                }
            }
        }



        //CONSTRUCTORS
        /// <summary>
        /// Creates a new, empty instance of <see cref="SQLite.Scaffolder.SQLiteDatabase"/> class
        /// </summary>
        internal SQLiteDatabase()
        {
            this.Name = string.Empty;
            this.ConnectionString = string.Empty;

            DatabaseMapper databaseMapper = new DatabaseMapper();
            DatabaseDefinition = databaseMapper.MapDatabase(this);
        }

        /// <summary>
        /// Creates a new, empty instance of <see cref="SQLite.Scaffolder.SQLiteDatabase"/> class with a specific name. 
        /// Automatically creates and stores the connection string unless you specify one.
        /// </summary>
        /// <param name="databaseName">Name of the database that you want to use</param>
        /// <param name="connectionString">Optional parameter. Custom connection string that will be used to connect to your database file.</param>
        public SQLiteDatabase(string databaseName, string connectionString = "")
        {
            Name = databaseName;
            if(string.IsNullOrEmpty(connectionString))
            {
                ConnectionString = SQLiteDatabase.GenerateConnectionString(Name);
                SQLiteConnection = new SQLiteConnection(ConnectionString);
            }
            else
            {
                ConnectionString = connectionString;
                SQLiteConnection = new SQLiteConnection(ConnectionString);
            }            

            DatabaseMapper databaseMapper = new DatabaseMapper();
            DatabaseDefinition = databaseMapper.MapDatabase(this);
        }



        //PUBLIC METHODS
        /// <summary>
        /// Executes a SQL query on the database. Does not expect any results therefore it does not deliver any.
        /// </summary>
        /// <param name="query">SQL query that you want to execute on the database</param>
        public void SendQueryNoResponse(SQLiteCommand query, bool keepConnectionAlive = false)
        {
            if (SQLiteConnection != null)
            {
                if (keepConnectionAlive == false)
                {
                    OpenConnection();
                }

                SQLiteCommand command = query;
                command.Connection = this.SQLiteConnection;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                if (keepConnectionAlive == false)
                {
                    CloseConnection();
                }

            }
            else throw new NullReferenceException("SQLite connection cannot be null");
        }

        /// <summary>
        /// Executes a SQL query on the database. Expectes a response and wraps in a SQLiteDataReader for consumption by caller
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public SQLiteDataReader SendQueryGetResponse(SQLiteCommand query, bool keepConnectionOpen = false)
        {
            if (SQLiteConnection != null)
            {
                if (keepConnectionOpen == false)
                {
                    OpenConnection();
                }

                SQLiteCommand command = query;
                command.Connection = this.SQLiteConnection;
                SQLiteDataReader reader = command.ExecuteReader();
                return reader;
            }
            else throw new NullReferenceException("SQLite connection cannot be null");
        }

        /// <summary>
        /// Closes the database connection
        /// </summary>
        /// <returns></returns>
        public bool CloseConnection()
        {
            try
            {
                SQLiteConnection.Close();
                SQLiteConnection.ClearAllPools();
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// Opens the connection to the SQLite database. Returns true if success, false otherwise
        /// </summary>
        public bool OpenConnection()
        {
            try
            {
                SQLiteConnection = new SQLiteConnection(this.ConnectionString);
                SQLiteConnection.Open();
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        /// <summary>
        /// Creates a new SQLite database file. Database will have the specified file name.
        /// </summary>
        /// <returns>Returns true if succesfull, false otherwise</returns>
        public SQLiteOperationReport CreateNewFile()
        {
            try
            {
                string databaseCreationInfo = string.Format("{0}", Name);
                SQLiteConnection.CreateFile(databaseCreationInfo);
                ConnectionString = string.IsNullOrEmpty(ConnectionString) 
                    ? SQLiteDatabase.GenerateConnectionString(Name)
                    : ConnectionString;

                bool isOpen = OpenConnection();

                if (isOpen)
                {
                    // generate the SQL command that will create the database
                    SQLGenerator sqlGenerator = new SQLGenerator();
                    using (SQLiteCommand databaseCreationCommand = sqlGenerator.CreateDatabase(DatabaseDefinition))
                    {
                        //send the generated SQL command to the SQLite engine
                        SendQuery(databaseCreationCommand);

                        //close the connection to the database
                        CloseConnection();
                        return new SQLiteOperationReport { Message = string.Format("Database '{0}' created successfully", Name), IsSuccess = true, Errors = new List<string>() };
                    }
                }
                else
                {
                    return new SQLiteOperationReport
                    {
                        Message = string.Format("Database '{0}' was NOT created. Check errors for more details.", Name),
                        IsSuccess = false,
                        Errors = new List<string> { "Connection to the database was not open, when the code expected it to be in order to execute the SQL query. Operation aborted." }
                    };
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Disposes of the SQLite database
        /// </summary>
        public void Dispose()
        {
            if (this.SQLiteConnection != null)
            {
                CloseConnection();
            }
        }



        //PRIVATE METHODS
        private void SendQuery(SQLiteCommand sqlQuery)
        {
            if (SQLiteConnection != null)
            {
                SQLiteCommand command = sqlQuery;
                command.Connection = this.SQLiteConnection;
                command.ExecuteNonQuery();
                command.Dispose();
            }
            else throw new Exception("SQLite connection does not exist.");
        }



        ////PUBLIC STATIC METHODS        
        /// <summary>
        /// Generates a connection string for the SQLite database
        /// </summary>
        /// <param name="databaseName">Name of the database that you are connecting to</param>
        /// <param name="version">Optional parameter. Database version number. Defaults to 3</param>
        /// <returns></returns>
        public static string GenerateConnectionString(string databaseName, int version = 3)
        {
            return string.Format("Data Source={0}.sqlite;Version={1}", databaseName, version);
        }



    }
}
