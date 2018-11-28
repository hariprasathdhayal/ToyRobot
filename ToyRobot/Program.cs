using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool userExit = false;
            RobotClass rc = new RobotClass();
            Console.WriteLine("Please enter the command.Use X to quit");
            try
            {
                //loop until user feels to exit.
                while (!userExit)
                {
                    string enteredCommand = Console.ReadLine();
                    if (enteredCommand.ToUpper().Equals("X"))
                        break;
                    Console.WriteLine(rc.ProcessCommands(enteredCommand));
                    //Console.WriteLine();
                }
            }
            catch(Exception ex)
            {

            }

        }
    }
}
