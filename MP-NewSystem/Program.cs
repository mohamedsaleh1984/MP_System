using MP_NewSystem.Core;
using static System.Console;

namespace MP_NewSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isDev = true;

            if (isDev)
            {
                string[] sparams = { "citibike", "evening" };
                new MPCore().Start(sparams);
            }
            else
            {
                if (args.Length == 2)
                {
                    new MPCore().Start(args);
                }
                else
                {
                    WriteLine("Invalid Parameters...\nPlease enter system parameters as follow ApiClientName(MP|CitiBike) AppMode(Morning|Evening|Afternoon)\n example: MP Morning");
                }
            }
        }
    }
}
