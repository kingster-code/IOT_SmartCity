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
                Console.WriteLine($"Started Call API");
                _sim.CallAPI();
                Console.WriteLine($"Finished Call API");
                Task.Delay(10 * 1000).GetAwaiter().GetResult();
            }
        }
    }
}
