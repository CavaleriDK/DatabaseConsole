using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DatabaseConsole
{
    class Campermodel
    {
        int id;
        public string pref;
        public int maxPay;
        SQLiteCommand cmd;

        public Campermodel(string pref, int maxPay)
        {
            this.pref = pref;
            this.maxPay = maxPay;
            CreateModel();
        }

        public static void CreateTable()
        {
            string sqlexp = "Create table Campermodel (id integer primary key, pref string, maxPay integer)";
            SQLiteCommand command = Program.Connection.CreateCommand();
            command.CommandText = sqlexp;
            command.ExecuteNonQuery();

        }

        private void CreateModel()
        {
            cmd.CommandText = "Insert into Campermodel (id, pref, maxPay) VALUES (null," + this.pref + +this.maxPay + ")";
            cmd.ExecuteNonQuery();

            string sqlrow = "Select last_insert_rowid()";
            cmd.CommandText = sqlrow;
            this.id = (Int32)cmd.ExecuteScalar();
        }
    }
}
