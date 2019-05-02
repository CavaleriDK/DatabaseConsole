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
            Console.WriteLine($"Day #{RoundPassController.Instance.RoundNumber} has passed!");
            Console.WriteLine("This is what happened during the day:");
            Console.WriteLine();

            // General stats
            Console.WriteLine($"{RoundPassController.Instance.AmountOfCampers} number of campers visited the camping areas.");
            Console.WriteLine($"{123456} number of these campers found a place they want to rent.");
            Console.WriteLine($"A total of {RoundPassController.Instance.RoundPassedForPlayerOne.CampingpladsIncome + RoundPassController.Instance.RoundPassedForPlayerOne.CampingpladsIncome} income was shared between both camping grounds.");

            // Player one stats
            Console.WriteLine($"This is what happened in {CampsiteController.Instance.PlayerOne.Title}");
            Console.WriteLine($"{123456} number of campers chose your campsite.");
            Console.WriteLine($"{123456} of them found a nice tent.");
            Console.WriteLine($"{123456} of them prefered your caravans.");
            Console.WriteLine($"This means you had {123456} empty tents and {123456} empty caravans at the end of the day.");
            Console.WriteLine($"You earned at total of {123456} today, and have a total balance of {123456} now.");

            // Player two stats
            Console.WriteLine($"This is what happened in {CampsiteController.Instance.PlayerTwo.Title}");
            Console.WriteLine($"{123456} number of campers chose your campsite.");
            Console.WriteLine($"{123456} of them found a nice tent.");
            Console.WriteLine($"{123456} of them prefered your caravans.");
            Console.WriteLine($"This means you had {123456} empty tents and {123456} empty caravans at the end of the day.");
            Console.WriteLine($"You earned at total of {123456} today, and have a total balance of {123456} now.");

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
