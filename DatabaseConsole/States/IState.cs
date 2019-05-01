using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    interface IState
    {
        string StateName { get; }
        void Enter();
        void ExecuteLoop();
        void Exit();
    }
}
