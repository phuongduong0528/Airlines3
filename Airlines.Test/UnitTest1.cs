using System;
using System.Collections.Generic;
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
            find.CalculatePath(6, 2,new DateTime(2017,9,1));
            List<string> result1 = find.GetResult_FN();
            List<int[]> result2 = find.GetResult_SID();

        }
    }
}
