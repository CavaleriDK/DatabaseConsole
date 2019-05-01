using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DatabaseConsole
{
    class Program
    {
        private static SQLiteConnection connection;

        public static SQLiteConnection Connection
        {
            get
            {
                if(connection == null)
                {
                    connection = new SQLiteConnection();
                }
                return connection;
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
