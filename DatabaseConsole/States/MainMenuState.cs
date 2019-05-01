using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class MainMenuState : IState
    {
        public string StateName { get => "MainMenuState"; }

        private static MainMenuState instance;
        public static MainMenuState Instance
        {
            get
            {
                return (instance == null) ? instance = new MainMenuState() : instance;
            }
        }


        private bool lastInputContainedError;
        private bool showMainScreen;

        public void Enter()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            showMainScreen = true;
            lastInputContainedError = false;
        }

        public void ExecuteLoop()
        {
            Console.Clear();

            if (showMainScreen)
            {
                DisplayMainScreen();
            }
            else
            {
                DisplayUsernameScreen();
            }

            
        }

        public void Exit()
        {
            Console.Clear();
        }

        private void DisplayUsernameScreen()
        {
            // SKAL HOLDE LOGIKKEN TIL AT INDTASTE BRUGERNAVNE HER
            // OG TIL AT VALIDERE, AT MAN IKKE INDTASTER UGYLDIGE TING!

            // LIGE NU SKIFTER VI BARE STATE SOM ET EKSEMPEL
            Program.ChangeState(PlayerOneTurnState.Instance);
        }

        private void DisplayMainScreen()
        {
            Console.WriteLine("Welcome to Campingplads PVP Simulator Game!");
            Console.WriteLine("Please choose option: ");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Exit");
            Console.WriteLine();

            if (lastInputContainedError)
            {
                Console.WriteLine("PLEASE CHOOSE A CORRECT OPTION!");
                Console.WriteLine();
            }
            // Reset lastInputContainedError
            lastInputContainedError = false;

            switch (Console.ReadLine())
            {
                case "1":
                    showMainScreen = false;
                    break;

                case "2":
                    Environment.Exit(0);
                    break;

                default:
                    // Set last input as error, since it was not expected
                    lastInputContainedError = true;
                    break;
            }
        }
    }
}
