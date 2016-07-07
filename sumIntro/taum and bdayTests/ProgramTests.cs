using Microsoft.VisualStudio.TestTools.UnitTesting;
using taum_and_bday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taum_and_bday.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void costTest()
        {
            long b = 3, w = 6, x = 9, y = 1, z = 1;
            Assert.AreEqual(12, Program.cost(b,w,x,y,z));
        }

        [TestMethod]
        public void costTest1()
        {
            long b = 10, w = 10, x = 1, y = 1, z = 1;
            Assert.AreEqual(20, Program.cost(b, w, x, y, z));
        }
    }
}