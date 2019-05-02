using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class PlayerOneTurnState : IState
    {
        public string StateName { get => "PlayerOneTurnState"; }

        private static PlayerOneTurnState instance;
        public static PlayerOneTurnState Instance
        {
            get
            {
                return (instance == null) ? instance = new PlayerOneTurnState() : instance;
            }
        }

        string priceOfTent;
        string priceOfCaravan;
        int tentPrice = 0;
        int caravanPrice = 0;
        bool mistakesExists;

        public void Enter()
        {
            Console.Clear();
            Console.WriteLine("Loading... ");
            mistakesExists = false;
        }

        public void ExecuteLoop()
        {
            Console.Clear();

            int numberOfTents = CampsiteController.Instance.GetNumberOfUnitsForPlayer(CampsiteController.Instance.PlayerOne.ID, "Tent");
            int numberOfCaravans = CampsiteController.Instance.GetNumberOfUnitsForPlayer(CampsiteController.Instance.PlayerOne.ID, "Caravan");
            int weightCombined = (numberOfTents * CampsiteController.Instance.WeightOfTent) + (numberOfCaravans * CampsiteController.Instance.WeightOfCaravan);

            // Eksempel på, at få skrevet noget fra campsite controller ud.
            Console.WriteLine($"Welcome to {CampsiteController.Instance.PlayerOne.Title}'s Campsite!");
            Console.WriteLine("Stats:");
            Console.WriteLine($"Amount of tents: {numberOfTents}");
            Console.WriteLine($"Amount of caravans: {numberOfCaravans}");
            Console.WriteLine($"Total amount: {weightCombined} / {CampsiteController.Instance.MaxAmountOfUnitsP1}");
            Console.WriteLine($"Current price of tent rental: {CampsiteController.Instance.PlayerOne.PriceOfTent}");
            Console.WriteLine($"Current price of caravan rental: {CampsiteController.Instance.PlayerOne.PriceOfCaravan}");
            Console.WriteLine();
            
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("1: Add tent");
            Console.WriteLine("2: Add caravan");
            Console.WriteLine("3: Remove tent");
            Console.WriteLine("4: Remove caravan");
            Console.WriteLine("5: Change tent price");
            Console.WriteLine("6: Change caravan price");
            Console.WriteLine("7: End turn");

            if (mistakesExists)
            {
                Console.WriteLine("Enter a correct option");
            }
            mistakesExists = false;

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    CampsiteController.Instance.AddTent(true);
                    break;
                case ConsoleKey.D2:
                    CampsiteController.Instance.AddCaravan(true);
                    break;
                case ConsoleKey.D3:
                    CampsiteController.Instance.RemoveTent(true);
                    break;
                case ConsoleKey.D4:
                    CampsiteController.Instance.RemoveCaravan(true);
                    break;
                case ConsoleKey.D5:
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.WriteLine("Please Enter the price you want, between 1 & 1000");
                    priceOfTent = Console.ReadLine();
                    if(Int32.TryParse(priceOfTent, out tentPrice) && tentPrice >=1 && tentPrice <= 1000)
                    {
                        CampsiteController.Instance.SetTentPrice(priceOfTent, true);
                    }
                    else
                    {
                        mistakesExists = true;
                    }
                    break;
                case ConsoleKey.D6:
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.WriteLine("Please Enter the price you want, between 1 & 1000");
                    priceOfCaravan = Console.ReadLine();
                    if (Int32.TryParse(priceOfCaravan, out caravanPrice) && caravanPrice >=1 && caravanPrice <= 1000)
                    {
                        CampsiteController.Instance.SetCaravanPrice(priceOfCaravan, true);
                    }
                    else
                    {
                        mistakesExists = true;
                    }
                    break;
                case ConsoleKey.D7:
                    if (tentPrice == 0 && caravanPrice == 0)
                    {
                        mistakesExists = true;
                    }
                    else
                    {
                        Program.ChangeState(PlayerTwoTurnState.Instance);

                    }
                    break;
                default:
                    mistakesExists = true;
                    break;
            }

            
            // Printe noget om stats for ens campingplads

            // Printe hvilke muligheder man har for indtastninger (1 = ... , 2 = ... osv)

            // Printe fejl, hvis der var fejl i sidste input

            // SØRG FOR, AT IMPLEMENTERE HELE LORTET
        }


        public void Exit()
        {

        }
    }
}
