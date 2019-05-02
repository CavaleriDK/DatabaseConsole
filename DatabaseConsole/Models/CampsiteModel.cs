using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DatabaseConsole
{
    class CampsiteModel
    {
        int id;
        string title;
        int totalIncome = 0;
        int priceOfTent;
        int priceOfCaravan;
        SQLiteCommand cmd;

        public int ID { get => id; }
        public string Title { get => title; }
        public int TotalIncome { get => totalIncome; }
        public int PriceOfTent { get => priceOfTent; }
        public int PriceOfCaravan { get => priceOfCaravan; }

        public CampsiteModel(string title)
        {
            this.title = title;

            cmd = Program.Connection.CreateCommand();

            cmd.CommandText = "INSERT INTO campsitemodel (id, title, totalincome, priceoftent, priceofcaravan) VALUES (null, '" + this.title + "', 0, 0, 0)";
            cmd.ExecuteNonQuery();

            string sqlrowid = "SELECT last_insert_rowid()";
            cmd.CommandText = sqlrowid;
            this.id = Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static void CreateTable()
        {
            string sqlexp = "CREATE TABLE IF NOT EXISTS campsitemodel (id integer primary key, title VARCHAR(50), totalincome integer, priceoftent integer, priceofcaravan integer)";
            SQLiteCommand command = Program.Connection.CreateCommand();
            command.CommandText = sqlexp;
            command.ExecuteNonQuery();
        }

        public void UpdateTentPrice(int newPrice)
        {
            priceOfTent = newPrice;
            // update campsitemodel (tent_price) WHERE id = this.id
            cmd.CommandText = "UPDATE campsitemodel SET priceoftent = " + this.priceOfTent + " WHERE id =" + this.id;
            cmd.ExecuteNonQuery();
        }

        public void UpdateCaravanPrice(int newPrice)
        {
            priceOfCaravan = newPrice;
            // update campsitemodel (tent_price) WHERE id = this.id
            cmd.CommandText = "UPDATE campsitemodel SET priceofcaravan = " + this.priceOfCaravan + " WHERE id =" + this.id;
            cmd.ExecuteNonQuery();
        }

        public void ChangeTotalIncome(int earnings)
        {
            totalIncome += earnings;
            // INCREAMENT // UPDATE (total_income) VALUES(total_ WHERE id = this.id
            cmd.CommandText = "UPDATE campsitemodel SET totalincome = " + this.totalIncome + " WHERE id =" + this.id;
            cmd.ExecuteNonQuery();
        }
        public int MyID()
        {
            return this.id;
        }
    }
}

