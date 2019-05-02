using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class IntermediateState : IState
    {
        public string StateName => "IntermediateState";

        private static IntermediateState instance;
        public static IntermediateState Instance
        {
            get
            {
                return (instance == null) ? instance = new IntermediateState() : instance;
            }
        }

        public void Enter()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            // Prepare all calculations for this round
            RoundPassController.Instance.CalculateRoundEvents();
        }

        public void ExecuteLoop()
        {
            Console.Clear();

            Console.WriteLine($"Day #{RoundPassController.Instance.RoundNumber} has passed!");
            Console.WriteLine("This is what happened during the day:");
            Console.WriteLine();

            // General stats
            Console.WriteLine($"{RoundPassController.Instance.AmountOfCampers} number of campers visited the camping areas.");
            Console.WriteLine($"{RoundPassController.Instance.GetNumberOfCampersWithAUnitType()} number of these campers found a place they want to rent.");
            Console.WriteLine($"A total of {RoundPassController.Instance.RoundPassedForPlayerOne.CampingpladsIncome + RoundPassController.Instance.RoundPassedForPlayerTwo.CampingpladsIncome} income was shared between both camping grounds.");
            Console.WriteLine();
            Console.WriteLine();

            // Player one stats
            Console.WriteLine($"This is what happened in {CampsiteController.Instance.PlayerOne.Title}");
            Console.WriteLine($"{RoundPassController.Instance.GetNumberOfCampersByPlayerID(CampsiteController.Instance.PlayerOne.ID)} number of campers chose your campsite.");
            Console.WriteLine($"{RoundPassController.Instance.GetNumberOfCampersByPlayerID(CampsiteController.Instance.PlayerOne.ID, "Tent")} of them found a nice tent.");
            Console.WriteLine($"{RoundPassController.Instance.GetNumberOfCampersByPlayerID(CampsiteController.Instance.PlayerOne.ID, "Caravan")} of them prefered your caravans.");
            Console.WriteLine($"This means you had {CampsiteController.Instance.GetNumberOfUnitsForPlayer(CampsiteController.Instance.PlayerOne.ID, "Tent") - RoundPassController.Instance.GetNumberOfCampersByPlayerID(CampsiteController.Instance.PlayerOne.ID, "Tent")} empty tents and {CampsiteController.Instance.GetNumberOfUnitsForPlayer(CampsiteController.Instance.PlayerOne.ID, "Caravan") - RoundPassController.Instance.GetNumberOfCampersByPlayerID(CampsiteController.Instance.PlayerOne.ID, "Caravan")} empty caravans at the end of the day.");
            Console.WriteLine($"You earned at total of {RoundPassController.Instance.RoundPassedForPlayerOne.CampingpladsIncome} today, and have a total balance of {CampsiteController.Instance.PlayerOne.TotalIncome} now.");
            Console.WriteLine();
            Console.WriteLine();

            // Player two stats
            Console.WriteLine($"This is what happened in {CampsiteController.Instance.PlayerTwo.Title}");
            Console.WriteLine($"{RoundPassController.Instance.GetNumberOfCampersByPlayerID(CampsiteController.Instance.PlayerTwo.ID)} number of campers chose your campsite.");
            Console.WriteLine($"{RoundPassController.Instance.GetNumberOfCampersByPlayerID(CampsiteController.Instance.PlayerTwo.ID, "Tent")} of them found a nice tent.");
            Console.WriteLine($"{RoundPassController.Instance.GetNumberOfCampersByPlayerID(CampsiteController.Instance.PlayerTwo.ID, "Caravan")} of them prefered your caravans.");
            Console.WriteLine($"This means you had {CampsiteController.Instance.GetNumberOfUnitsForPlayer(CampsiteController.Instance.PlayerTwo.ID, "Tent") - RoundPassController.Instance.GetNumberOfCampersByPlayerID(CampsiteController.Instance.PlayerTwo.ID, "Tent")} empty tents and {CampsiteController.Instance.GetNumberOfUnitsForPlayer(CampsiteController.Instance.PlayerTwo.ID, "Caravan") - RoundPassController.Instance.GetNumberOfCampersByPlayerID(CampsiteController.Instance.PlayerTwo.ID, "Caravan")} empty caravans at the end of the day.");
            Console.WriteLine($"You earned at total of {RoundPassController.Instance.RoundPassedForPlayerTwo.CampingpladsIncome} today, and have a total balance of {CampsiteController.Instance.PlayerTwo.TotalIncome} now.");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press `spacebar` to continue when both players are ready");

            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                Program.ChangeState(PlayerOneTurnState.Instance);
            }
        }

        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("Loading...");
        }
    }
}
