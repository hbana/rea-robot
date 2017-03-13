using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rea_robot_code;

namespace code_tests
{
    [TestClass]
    public class Simulator
    {
        private Tabletop oTabletop;

        [TestInitialize]
        public void TestSetup()
        {
            oTabletop = new Tabletop();
        }

        [TestMethod]
        public void RotateLeft()
        {
            Assert.IsTrue(oTabletop.Place("0,0,NORTH"));
            Assert.IsTrue(oTabletop.Left());
            Assert.AreEqual(oTabletop.Report(), "0,0,WEST");
        }

        [TestMethod]
        public void RotateRight()
        {
            Assert.IsTrue(oTabletop.Place("0,0,NORTH"));
            Assert.IsTrue(oTabletop.Right());
            Assert.AreEqual(oTabletop.Report(), "0,0,EAST");
        }

        [TestMethod]
        public void MoveOneUnit()
        {
            Assert.IsTrue(oTabletop.Place("0,0,NORTH"));
            Assert.IsTrue(oTabletop.Move());
            Assert.AreEqual(oTabletop.Report(), "0,1,NORTH");
        }

        [TestMethod]
        public void MoveMultipleUnits()
        {
            Assert.IsTrue(oTabletop.MoveRobot("PLACE 1,2,EAST"));
            Assert.IsTrue(oTabletop.MoveRobot("MOVE"));
            Assert.IsTrue(oTabletop.MoveRobot("MOVE"));
            Assert.IsTrue(oTabletop.MoveRobot("LEFT"));
            Assert.IsTrue(oTabletop.MoveRobot("MOVE"));
            Assert.AreEqual(oTabletop.Report(), "3,3,NORTH");
        }
    }
}
