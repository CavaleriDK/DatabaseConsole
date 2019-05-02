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

        public void Enter()
        {
            Console.Clear();
            Console.WriteLine("Loading... ");
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
            Console.WriteLine($"Total amount: {weightCombined} / {CampsiteController.Instance.MaxAmountOfUnits}");
            Console.WriteLine($"Current price of tent rental: {CampsiteController.Instance.PlayerOne.PriceOfTent}");
            Console.WriteLine($"Current price of caravan rental: {CampsiteController.Instance.PlayerOne.PriceOfCaravan}");
            Console.WriteLine();

            Console.WriteLine("Please select an option: ");
            Console.WriteLine("1: Add tent");
            Console.WriteLine("2: Add caravan");
            Console.WriteLine("3: Remove tent");
            Console.WriteLine("4: Remove caravan");

            Console.ReadLine();
            // Printe noget om stats for ens campingplads

            // Printe hvilke muligheder man har for indtastninger (1 = ... , 2 = ... osv)

            // Printe fejl, hvis der var fejl i sidste input

            // SØRG FOR, AT IMPLEMENTERE HELE LORTET
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
