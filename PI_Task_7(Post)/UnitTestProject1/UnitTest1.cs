using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Great_Post;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Program.GreatPost("11101110"), true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(Program.GreatPost("11110110"), true);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(Program.GreatPost("11111111"), false);
        }
    }
}
