using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorService
{
    public class LogicRunner
    {
        private readonly SimExecuter _sim;

        public LogicRunner(SimExecuter sim)
        {
            _sim = sim;
        }    

        public void Runtime()
        {
            while (true)
            {
                _sim.CallAPI();
                Task.Delay(10 * 1000).GetAwaiter().GetResult();
            }
        }
    }
}
