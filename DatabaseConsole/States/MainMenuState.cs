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
        private string playerOneName;
        private string playerTwoName;

        /// <summary>
        /// Called whenever this state is entered
        /// </summary>
        public void Enter()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            showMainScreen = true;
            lastInputContainedError = false;
            playerOneName = "";
            playerTwoName = "";
        }

        /// <summary>
        /// Called continuously every frame
        /// </summary>
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

        /// <summary>
        /// Called whenever you exit this state
        /// </summary>
        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            // Save player names before leaving this state
            CampsiteController.Instance.AddCampsiteByName(playerOneName, true);
            CampsiteController.Instance.AddCampsiteByName(playerTwoName, false);
        }

        /// <summary>
        /// Used to show the screen where players can input their name
        /// </summary>
        private void DisplayUsernameScreen()
        {
            Console.WriteLine($"Player ones camping ground: {playerOneName}");
            Console.WriteLine($"Player twos camping ground: {playerTwoName}");

            if (playerOneName == "")
            {
                Console.WriteLine("Player one: Please enter the name of your camping grounds: ");
            }
            else
            {
                Console.WriteLine("Player two: Please enter the name of your camping grounds: ");
            }
            Console.WriteLine();

            if (lastInputContainedError)
            {
                Console.WriteLine("PLEASE CHOOSE A CORRECT OPTION!");
                Console.WriteLine();
            }
            // Reset lastInputContainedError
            lastInputContainedError = false;

            string input = Console.ReadLine();

            if (input.Length > 50 || input == "")
            {
                lastInputContainedError = true;
            }
            else
            {
                // Set player 1 name
                if (playerOneName == "")
                {
                    playerOneName = input;
                }
                // Set player 2 name and change state
                else
                {
                    playerTwoName = input;
                    Program.ChangeState(PlayerOneTurnState.Instance);
                }
            }
        }

        /// <summary>
        /// Used to show only the main menu screen
        /// </summary>
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
