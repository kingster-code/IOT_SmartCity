using System;
using System.Threading.Tasks;

namespace SimulatorService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SimExecuter sim = new SimExecuter(15000, 5);

            while (true)
            {
                sim.CallAPI();
                Task.Delay(1000);
            }
        }
    }
}
