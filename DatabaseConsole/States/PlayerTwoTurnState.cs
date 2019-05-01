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

        public void Enter()
        {
            throw new NotImplementedException();
        }

        public void ExecuteLoop()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
