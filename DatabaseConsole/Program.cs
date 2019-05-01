using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class Program
    {
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
