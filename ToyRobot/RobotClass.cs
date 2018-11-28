using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class RobotClass
    {
        //Defining the size of the table 5X5
        private int xTableLowerBoundary=0;
        private int yTableLowerBoundary = 0;
        private int xTableUpperBoundary = 5;
        private int yTableUpperBoundary = 5;
        //As said in requirement initial position would be (0,0) and southwest setting default value.
        private int xPos = -1;
        private int yPos = -1;
        //facing 
        string facing = "";

        public string placerobot(string placeCommand)
        {
            //Assuming input command will be like PLACE X,Y,F
            char[] splitChars = {',',' '};
            string[] cmdArray = placeCommand.Split(splitChars);
            xPos = Convert.ToInt32(cmdArray[1]);
            yPos = Convert.ToInt32(cmdArray[2]);
            facing = cmdArray[3];
            //we need to check whether user trying to initially place the robot outside of defined x,y coordinates.
            if (xPos > xTableUpperBoundary || yPos > yTableUpperBoundary)
                return "Robot cannot be placed outside of table boundary";
            else if(xPos<xTableLowerBoundary || yPos < yTableLowerBoundary)
                return "Robot cannot be placed outside of table boundary";
            else
                return "";
        }

        public string Move()
        {
            switch (facing)
            {
                case "NORTH":
                    yPos++;
                    break;
                case "EAST":
                    xPos++;
                    break;
                case "WEST":
                    //yPos--;
                    xPos--;
                    break;
                case "SOUTH":
                    //xPos--;
                    yPos--;
                    break;
            }
            //  Console.WriteLine("xPos " + xPos + " yPos " + yPos);
            return "";
        }

        //Handling left or Right.
        public string LeftOrRight(string cmd)
        {
            if (cmd == "LEFT")
            {
                //take facing anti clockwise 90degss
                if (facing == "NORTH")//90 degree left of north is west.
                    facing = "WEST";
                else if (facing == "WEST")//90 degree left of north is south
                    facing = "SOUTH";
                else if (facing == "SOUTH")//90 degree left of South is east
                    facing = "EAST";
                else if (facing == "EAST")//90 degree left of East is North
                    facing = "NORTH";

                return "";
            }
            else if(cmd=="RIGHT")
            {
                //take facing clockwise 90degss
                if (facing == "NORTH")//90 degree right of north is east.
                    facing = "EAST";
                else if (facing == "EAST")//90 degree right of east is south.
                    facing = "SOUTH";
                else if (facing == "SOUTH")//90 degree right of south is west.
                    facing = "WEST";
                else if (facing == "WEST")//90 degree right of WEST is North.
                    facing = "NORTH";

                return "";

            }
            else
            {
                return "Invalid command";
            }

        }
        //Method for printing report
        public string PrintReport()
        {
            return "Output: " + xPos + "," + yPos + "," + facing;
        }

        //Main function to perform above calculations
        public string ProcessCommands(string cnsoleInput)
        {
            string output = string.Empty;
            string cnslecmd = cnsoleInput.ToUpper();
            if (cnslecmd.Contains("PLACE"))
                output = placerobot(cnslecmd);
            else if (cnslecmd == "MOVE")
                output = Move();
            else if (cnslecmd == "LEFT" || cnslecmd == "RIGHT")
                output = LeftOrRight(cnslecmd);
            else if (cnslecmd == "REPORT")
                output = PrintReport();
            else
                output = "Not a valid command";

            return output;

        }

    }
}
