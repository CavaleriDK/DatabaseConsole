using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DatabaseConsole
{
    class UnitTypeModel
    {
        int id;
        string type;
        int campingGroundsId;
        SQLiteCommand cmd;

        public int ID { get => id; }
        public string Type { get => type; }
        public int CampingGroundsID { get => campingGroundsId; }

        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="type">The type of unit you want to make, in this case either caravan or tent</param>
        /// <param name="campingGroundsId">the ID of the camping ground so we know who the player is</param>
        public UnitTypeModel(string type, int campingGroundsId)
        {
            this.campingGroundsId = campingGroundsId;
            this.type = type;
            cmd = Program.Connection.CreateCommand();

            if (type == "Tent")
            {
                NewTent();
            }
            else if (type == "Caravan")
            {
                NewCaravan();
            }
        }
        /*
         * UnitTypeModel mitTelt = new UnitTypeModel("telt");
         * mitTelt.id // 6;
         * 
         * mitTelt.Remove() DROP FROM TABLE WHERE ID = this.id
         */
        /// <summary>
        /// creates a table in the database if it does not alreadt exist.
        /// </summary>
        public static void CreateTable()
        {
            string sqlexp = "CREATE TABLE IF NOT EXISTS unittypemodel (id integer primary key, type VARCHAR(15), campingpladsid integer)";
            SQLiteCommand command = Program.Connection.CreateCommand();
            command.CommandText = sqlexp;
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// Creates a row in the table and returns the ID of the row, also gives the name tent.( Hvis der er problemer her prøv med '' omkring int værdierne this.campingground og this.id )
        /// </summary>
        private void NewTent()
        {
            cmd.CommandText = "INSERT INTO unittypemodel (id, type, campingpladsid) VALUES (null, 'Tent', " + this.campingGroundsId + ")";
            cmd.ExecuteNonQuery();

            string sqlrow = "SELECT last_insert_rowid()";
            cmd.CommandText = sqlrow;
            this.id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        /// <summary>
        /// Creates a row in the table and returns the ID of the row, also gives the name caravan
        /// </summary>
        private void NewCaravan()
        {
            cmd.CommandText = "INSERT INTO unittypemodel (id, type, campingpladsid) VALUES (null, 'Caravan', " + this.campingGroundsId + ")";
            cmd.ExecuteNonQuery();

            string sqlrow = "SELECT last_insert_rowid()";
            cmd.CommandText = sqlrow;
            this.id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        /// <summary>
        /// Removes a row in the database depending on the ID
        /// </summary>
        public void Remove()
        {
            cmd.CommandText = "DELETE FROM unittypemodel WHERE id=" + this.id;
            cmd.ExecuteNonQuery();
        }
    }
}
