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
        const string CONNECTIONSTRING = @"Data Source=camping.db;version=3;New=true;Compress=true";

        private static SQLiteConnection connection;

        public static SQLiteConnection Connection
        {
            get
            {
                if(connection == null)
                {
                    connection = new SQLiteConnection(CONNECTIONSTRING);
                }
                return connection;
            }
        }
        private static IState currentState;
        public static IState CurrentState { get => currentState; }

        static void Main(string[] args)
        {
            // Initialize whatver logic is needed first
            Initialize();

            // Run the update loop
            while (true)
            {
                currentState.ExecuteLoop();
            }
        }

        private static void Initialize()
        {
            // Setup main menu as first state when starting game
            ChangeState(MainMenuState.Instance);

            Connection.Open();

            //Create tables
            CampsiteModel.CreateTable();
            RoundPassedModel.CreateDatabaseStructure();
            Campermodel.CreateTable();
            UnitTypeModel.CreateTable();

        }

        public static void ChangeState(IState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            currentState = newState;

            currentState.Enter();
        }
    }
}
