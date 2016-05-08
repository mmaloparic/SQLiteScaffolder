using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder
{
    public class SQLiteTable<T> where T : SQLiteEntity
    {
        private SQLiteDatabase Database;

        public SQLiteTable(SQLiteDatabase database)
        {
            Database = database;
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }        

        public IEnumerable<T> Where(string sql)
        {
            throw new NotImplementedException();

            /*
            string sqlSelectStatement = "SELECT * FROM {0}";
            string sqlFullStatement = sqlSelectStatement + sql;
            SQLiteCommand command = new SQLiteCommand(sqlFullStatement, Database.SQLiteConnection);
            SQLiteDataReader data = Database.SendQueryGetResponse(command);

            return null;
            */
        }
    }
}
