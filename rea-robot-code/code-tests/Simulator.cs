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

        }

        [TestMethod]
        public void RotateRight()
        {

        }

        [TestMethod]
        public void MoveOneUnit()
        {

        }

        [TestMethod]
        public void ReportCurrentPosition()
        {

        }
    }
}
