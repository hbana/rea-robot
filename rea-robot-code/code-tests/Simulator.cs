using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rea_robot_code;

namespace code_tests
{
    [TestClass]
    public class Simulator
    {
        private RobotSimulator oRobotSimulator;

        [TestInitialize]
        public void TestSetup()
        {
            oRobotSimulator = new RobotSimulator();
        }

        [TestMethod]
        public void RotateLeft()
        {
            Assert.IsTrue(oRobotSimulator.Place("0,0,NORTH"));
            Assert.IsTrue(oRobotSimulator.Left());
            Assert.AreEqual(oRobotSimulator.Report(), "0,0,WEST");
        }

        [TestMethod]
        public void RotateRight()
        {
            Assert.IsTrue(oRobotSimulator.Place("0,0,NORTH"));
            Assert.IsTrue(oRobotSimulator.Right());
            Assert.AreEqual(oRobotSimulator.Report(), "0,0,EAST");
        }

        [TestMethod]
        public void MoveOneUnit()
        {
            Assert.IsTrue(oRobotSimulator.Place("0,0,NORTH"));
            Assert.IsTrue(oRobotSimulator.Move());
            Assert.AreEqual(oRobotSimulator.Report(), "0,1,NORTH");
        }

        [TestMethod]
        public void MoveMultipleUnits()
        {
            Assert.IsTrue(oRobotSimulator.MoveRobot("PLACE 1,2,EAST"));
            Assert.IsTrue(oRobotSimulator.MoveRobot("MOVE"));
            Assert.IsTrue(oRobotSimulator.MoveRobot("MOVE"));
            Assert.IsTrue(oRobotSimulator.MoveRobot("LEFT"));
            Assert.IsTrue(oRobotSimulator.MoveRobot("MOVE"));
            Assert.AreEqual(oRobotSimulator.Report(), "3,3,NORTH");
        }

        [TestMethod]
        public void CheckRobotAbsent()
        {
            Assert.IsFalse(oRobotSimulator.Move());
            Assert.IsFalse(oRobotSimulator.Right());
            Assert.IsFalse(oRobotSimulator.Left());
            Assert.AreEqual(oRobotSimulator.Report(), "No robot placed on the tabletop");
        }

        [TestMethod]
        public void PreventFromFalling()
        {
            Assert.IsFalse(oRobotSimulator.Place("6,6,NORTH"));
            Assert.IsTrue(oRobotSimulator.Place("0,0,NORTH"));
            Assert.IsTrue(oRobotSimulator.Left());
            Assert.IsFalse(oRobotSimulator.Move());
            Assert.IsTrue(oRobotSimulator.Right());
            Assert.IsTrue(oRobotSimulator.Move());
            Assert.IsTrue(oRobotSimulator.Left());
            Assert.IsFalse(oRobotSimulator.Move());
            Assert.IsTrue(oRobotSimulator.Place("4,4,SOUTH"));
            Assert.IsTrue(oRobotSimulator.Left());
            Assert.IsFalse(oRobotSimulator.Move());
            Assert.IsTrue(oRobotSimulator.Place("0,4,WEST"));
            Assert.IsTrue(oRobotSimulator.Right());
            Assert.IsFalse(oRobotSimulator.Move());
            Assert.IsTrue(oRobotSimulator.Place("4,0,EAST"));
            Assert.IsTrue(oRobotSimulator.Right());
            Assert.IsFalse(oRobotSimulator.Move());
        }
    }
}
