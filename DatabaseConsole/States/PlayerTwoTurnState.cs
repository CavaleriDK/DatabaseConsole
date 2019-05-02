using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class PlayerTwoTurnState : IState
    {
        public string StateName => throw new NotImplementedException();

        private static PlayerTwoTurnState instance;
        public static PlayerTwoTurnState Instance
        {
            get
            {
                return (instance == null) ? instance = new PlayerTwoTurnState() : instance;
            }
        }

        string priceOfTent;
        string priceOfCaravan;
        int tentPrice;
        int caravanPrice;
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

            int numberOfTents = CampsiteController.Instance.GetNumberOfUnitsForPlayer(CampsiteController.Instance.PlayerTwo.ID, "Tent");
            int numberOfCaravans = CampsiteController.Instance.GetNumberOfUnitsForPlayer(CampsiteController.Instance.PlayerTwo.ID, "Caravan");
            int weightCombined = (numberOfTents * CampsiteController.Instance.WeightOfTent) + (numberOfCaravans * CampsiteController.Instance.WeightOfCaravan);

            // Eksempel på, at få skrevet noget fra campsite controller ud.
            Console.WriteLine($"Welcome to {CampsiteController.Instance.PlayerTwo.Title}'s Campsite!");
            Console.WriteLine("Stats:");
            Console.WriteLine($"Amount of tents: {numberOfTents}");
            Console.WriteLine($"Amount of caravans: {numberOfCaravans}");
            Console.WriteLine($"Total amount: {weightCombined} / {CampsiteController.Instance.MaxAmountOfUnitsP2}");
            Console.WriteLine($"Current price of tent rental: {CampsiteController.Instance.PlayerTwo.PriceOfTent}");
            Console.WriteLine($"Current price of caravan rental: {CampsiteController.Instance.PlayerTwo.PriceOfCaravan}");
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
                Console.WriteLine();
            }
            mistakesExists = false;

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CampsiteController.Instance.AddTent(false);
                    break;
                case "2":
                    CampsiteController.Instance.AddCaravan(false);
                    break;
                case "3":
                    CampsiteController.Instance.RemoveTent(false);
                    break;
                case "4":
                    CampsiteController.Instance.RemoveCaravan(false);
                    break;
                case "5":
                    Console.WriteLine("Please Enter the price you want, between 1 & 1000");
                    priceOfTent = Console.ReadLine();
                    if (Int32.TryParse(priceOfTent, out tentPrice) && tentPrice >= 1 && tentPrice <= 1000)
                    {
                        CampsiteController.Instance.SetTentPrice(priceOfTent, false);
                    }
                    else
                    {
                        mistakesExists = true;
                    }
                    break;
                case "6":
                    Console.WriteLine("Please Enter the price you want, between 1 & 1000");
                    priceOfCaravan = Console.ReadLine();
                    if (Int32.TryParse(priceOfCaravan, out caravanPrice) && caravanPrice >= 1 && caravanPrice <= 1000)
                    {
                        CampsiteController.Instance.SetCaravanPrice(priceOfCaravan, false);
                    }
                    else
                    {
                        mistakesExists = true;
                    }
                    break;
                case "7":
                    if(tentPrice == 0 && caravanPrice == 0)
                    {
                        mistakesExists = true;
                    }
                    else
                    {
                        Program.ChangeState(IntermediateState.Instance);
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
