using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DatabaseConsole
{
    class RoundPassedModel
    {
        static string tableName = "RoundPassed";
        static string extraTableName = "RoundPassedUnitType";
        static string RoundPassedQuery = "CREATE TABLE IF NOT EXISTS " + tableName + "(id integer primary key, campingplads_income integer, campingplads_id integer, round_number integer)";
        static string RoundPassedUnitTypeQuery = "CREATE TABLE IF NOT EXISTS " + extraTableName + "(id integer primary key, round_passed_id integer, unit_type_id integer, campist_id integer)";
        string lastInsertRowId = "SELECT last_insert_rowid()";

        private int id;
        private int campingpladsIncome;
        private int campingpladsId;
        private int roundNumber;

        public int ID { get => id; }
        public int CampingpladsIncome { get => campingpladsIncome; }
        public int CampingpladsId { get => campingpladsId; }
        public int RoundNumber { get => roundNumber; }

        public RoundPassedModel(int campingplads_id, int round_number)
        {
            this.campingpladsId = campingplads_id;
            this.roundNumber = round_number;
            this.campingpladsIncome = 0;

            CreateRoundAsRow();
        }


        public static void CreateDatabaseStructure()
        {
            SQLiteCommand cmd = Program.Connection.CreateCommand();
            cmd.CommandText = RoundPassedQuery;
            cmd.ExecuteNonQuery();

            cmd.CommandText = RoundPassedUnitTypeQuery;
            cmd.ExecuteNonQuery();
        }

        private void CreateRoundAsRow()
        {
            string sqlInsert = "INSERT INTO " + tableName + " (campingplads_income, campingplads_id, round_number) VALUES (" + this.campingpladsIncome + ", " + this.campingpladsId + ", " + this.roundNumber + ");";

            SQLiteCommand cmd = Program.Connection.CreateCommand();
            cmd.CommandText = sqlInsert;
            cmd.ExecuteNonQuery();

            cmd.CommandText = lastInsertRowId;
            this.id = Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void UpdateIncome(int earnings)
        {
            SQLiteCommand cmd = Program.Connection.CreateCommand();

            this.campingpladsIncome += earnings;
            string sql = "UPDATE " + tableName + " SET campingplads_income = " + this.campingpladsIncome + " WHERE id=" + this.id;

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

    }

    class RoundPassedUnitTypeModel
    {
        static string extraTableName = "RoundPassedUnitType";
        string lastInsertRowId = "SELECT last_insert_rowid()";

        private int id;
        private int roundPassedId;
        private int unittypeId;
        private int campistId;

        public int ID { get => id; }
        public int RoundPassedID { get => roundPassedId; }
        public int UnitTypeID { get => unittypeId; }
        public int CampistID { get => campistId; }

        public RoundPassedUnitTypeModel(int roundpassed_id, int unittype_id)
        {
            this.roundPassedId = roundpassed_id;
            this.unittypeId = unittype_id;
            this.campistId = 0;

            CreateAsRow();
        }

        private void CreateAsRow()
        {
            string sqlInsert = "INSERT INTO " + extraTableName + " (round_passed_id, unit_type_id) VALUES (" + this.roundPassedId + ", " + this.unittypeId + ");";

            SQLiteCommand cmd = Program.Connection.CreateCommand();
            cmd.CommandText = sqlInsert;
            cmd.ExecuteNonQuery();

            cmd.CommandText = lastInsertRowId;
            this.id = Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void AddCampist(int campist_id)
        {
            this.campistId = campist_id;
            SQLiteCommand cmd = Program.Connection.CreateCommand();

            string sql = "UPDATE " + extraTableName + " SET campist_id = " + campist_id + " WHERE id=" + this.id;

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }
}

