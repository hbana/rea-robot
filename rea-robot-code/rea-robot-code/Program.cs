using System;

namespace rea_robot_code
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;
            var oRobotSimulator = new RobotSimulator();

            Console.WriteLine("Enter commands to place & move a robot on the 5x5 tabletop...\r\n");

            while (command.ToLowerInvariant() != "report")
            {
                command = Console.ReadLine();
            }

            Console.WriteLine(oRobotSimulator.Report());
            Console.WriteLine("\r\nPress any key to terminate the program...");
            Console.ReadKey();
        }
    }
}
