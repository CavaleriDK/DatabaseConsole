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

        public void Enter()
        {
            Console.Clear();
            Console.WriteLine("Loading... ");
        }

        public void ExecuteLoop()
        {
            Console.Clear();

            // Eksempel på, at få skrevet noget fra campsite controller ud.
            Console.WriteLine(@"Welcome to {CampsiteController.Instance.PlayerOne.Title}'s Campsite!");

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
