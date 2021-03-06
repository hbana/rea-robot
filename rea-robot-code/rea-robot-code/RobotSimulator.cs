﻿using System;

namespace rea_robot_code
{
    /// <summary>
    /// Simulates a toy robot's movement on a 5x5 dimensional tabletop
    /// </summary>
    public class RobotSimulator
    {
        private int x;
        private int y;
        private string direction;
        private string[] arrDirections;

        /// <summary>
        /// Constructor for the simulator class
        /// </summary>
        public RobotSimulator()
        {
            // store all geo directions in an array for easy retrieval
            arrDirections = new string[] { "north", "east", "south", "west" };
        }

        /// <summary>
        /// Places and moves the toy robot on the tabletop as per the supplied command
        /// </summary>
        /// <param name="argCommand">Command entered on this interface (e.g. PLACE 1,2,SOUTH)</param>
        /// <returns>True/False indicating success/failure of robot's movement</returns>
        public bool MoveRobot(string argCommand)
        {
            // seggregate movememnt command from position parameters
            var arrCommand = argCommand.Split(' ');
            var movement = arrCommand[0];
            var position = arrCommand.Length == 2 ? arrCommand[1] : string.Empty;

            // move or rotate the robot based on the controller's command 
            switch (movement.ToLowerInvariant())
            {
                case "place":
                    return Place(position);
                case "left":
                    return Left();
                case "right":
                    return Right();
                case "move":
                    return Move();
                default:
                    return false;
            }
        }

        /// <summary>
        /// Positions a robot on a 5x5 square tabletop based on supplied parameter
        /// </summary>
        /// <param name="argPosition">Position of the robot (e.g. 0,0,SOUTH)</param>
        /// <returns>True/False indicating success/failure of robot's positioning</returns>
        public bool Place(string argPosition)
        {
            // return false immediately if position undefined
            if (string.IsNullOrEmpty(argPosition))
                return false;

            // extract x, y and direction into an array
            var arrPosition = argPosition.Split(',');

            // get values from array
            x = Convert.ToInt32(arrPosition[0]);
            y = Convert.ToInt32(arrPosition[1]);
            direction = arrPosition[2].ToLowerInvariant();

            // validate the position params passed in with PLACE command
            x = x >= 0 && x < 5 ? x : -1;
            y = y >= 0 && y < 5 ? y : -1;
            direction = x == -1 && y == -1 ? string.Empty : direction;

            return string.IsNullOrEmpty(direction) ? false : true;
        }

        /// <summary>
        /// Moves the robot to one unit towards left on the tabletop, provided 
        /// the robot is not already positioned on one of the left-most units.
        /// </summary>
        /// <returns>True/False indicating success/failure of robot's movement</returns>
        public bool Left()
        {
            // return false immediately if direction undefined
            if (string.IsNullOrEmpty(direction))
                return false;

            // based on the current direction of robot, decide which direction the robot
            // should now be pointing to after rotating left in its current position
            var arrayIndex = Array.FindIndex(arrDirections, d => d.Equals(direction));
            var newArrayIndex = arrayIndex == 0 ? arrDirections.Length - 1 : arrayIndex - 1;
            direction = arrDirections[newArrayIndex];

            return true;
        }

        /// <summary>
        /// Moves the robot to one unit towards right on the tabletop, provided 
        /// the robot is not already positioned on one of the right-most units.
        /// </summary>
        /// <returns>True/False indicating success/failure of robot's movement</returns>
        public bool Right()
        {
            // return false immediately if direction undefined
            if (string.IsNullOrEmpty(direction))
                return false;

            // based on the current direction of robot, decide which direction the robot
            // should now be pointing to after rotating right in its current position
            var arrayIndex = Array.FindIndex(arrDirections, d => d.Equals(direction));
            var newArrayIndex = arrayIndex == 3 ? 0 : arrayIndex + 1;
            direction = arrDirections[newArrayIndex];

            return true;
        }

        /// <summary>
        /// Moves the robot in either north/east/south/west direction
        /// </summary>
        /// <returns>True/False indicating success/failure of robot's movement</returns>
        public bool Move()
        {
            var hasMoved = true;

			// move robot one unit in the direction it's currently facing, but prevent
			// it from moving outwards if positioned in one of the bordering units
			switch (direction)
            {
                case "north":
                    hasMoved = y == 4 ? false : true;
                    y = y == 4 ? 4 : y + 1;
                    break;
                case "south":
                    hasMoved = y == 0 ? false : true;
                    y = y == 0 ? 0 : y - 1;
                    break;
                case "east":
                    hasMoved = x == 4 ? false : true;
                    x = x == 4 ? 4 : x + 1;
                    break;
                case "west":
                    hasMoved = x == 0 ? false : true;
                    x = x == 0 ? 0 : x - 1;
                    break;
                default:
                    hasMoved = false;
                    break;
            }

            return hasMoved;
        }

        /// <summary>
        /// Gets the current position of robot
        /// </summary>
        /// <returns>Current position of the robot (e.g. 2,3,SOUTH)</returns>
        public string Report()
        {
            // return appriopriate text, i.e. either current position of the robot or 
            // a message indicating robot's absence on tabletop
            return string.IsNullOrEmpty(direction) ? "No robot placed on the tabletop" : string.Format("{0},{1},{2}", x, y, direction.ToUpperInvariant());
        }
    }
}
