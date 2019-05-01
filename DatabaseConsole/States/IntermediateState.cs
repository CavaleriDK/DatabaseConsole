﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class IntermediateState : IState
    {
        public string StateName => throw new NotImplementedException();

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
