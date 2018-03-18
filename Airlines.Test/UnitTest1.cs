using System;
using Airlines.Business.Manager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airlines.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FindRoute find = new FindRoute();
            find.Inputdata();

        }
    }
}
