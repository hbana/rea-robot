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

            // read commands in a succession from the command prompt and move 
            // the robot accordingly until asked to report its final position
            while (1==1)
            {
                command = Console.ReadLine();

                if (command.ToLowerInvariant() == "report")
                    break;

                if (!oRobotSimulator.MoveRobot(command))
                    Console.WriteLine("...Invalid command");
            }

            Console.WriteLine(oRobotSimulator.Report());
            Console.WriteLine("\r\nPress any key to terminate the program...");
            Console.ReadKey();
        }
    }
}
