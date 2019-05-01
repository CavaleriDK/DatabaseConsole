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
