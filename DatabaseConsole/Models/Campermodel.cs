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
        private string pref;
        private int maxPay;
        private int roundNumber;
        private int unitTypeId;
        SQLiteCommand cmd;

        public int ID { get => id; }
        public string Pref { get => pref; }
        public int MaxPay { get => maxPay; }
        public int RoundNumber { get => roundNumber; }
        public int UnitTypeId { get => unitTypeId; }


        public Campermodel(string pref, int maxPay, int round_number)
        {
            this.pref = pref;
            this.maxPay = maxPay;
            this.roundNumber = round_number;
            CreateModel();
        }

        public static void CreateTable()
        {
            string sqlexp = "CREATE TABLE IF NOT EXISTS Campermodel (id integer primary key, pref string, maxPay integer, round_number integer, unittype_id integer)";
            SQLiteCommand command = Program.Connection.CreateCommand();
            command.CommandText = sqlexp;
            command.ExecuteNonQuery();

        }

        private void CreateModel()
        {
            cmd.CommandText = "Insert into Campermodel (id, pref, maxPay, round_number) VALUES (null, " + this.pref + ", " + this.maxPay + ", " + this.roundNumber + ")";
            cmd.ExecuteNonQuery();

            string sqlrow = "Select last_insert_rowid()";
            cmd.CommandText = sqlrow;
            this.id = (Int32)cmd.ExecuteScalar();
        }

        public void ChangeUnitTypeID(int id)
        {
            this.unitTypeId = id;

            cmd.CommandText = "UPDATE Campermodel SET unittype_id = " + this.unitTypeId + "WHERE id =" + this.id;
            cmd.ExecuteNonQuery();
        }
    }
}
