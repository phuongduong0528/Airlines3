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
            find.Inputdata();

            find.Start_Date = new DateTime(2017, 9, 1);

            List<DateTime> list = find.STime[0, 1];
            List<DateTime> list2 = find.FTime[0, 1];

            find.FindFlightRoute(3, 5);
            List<List<string>> allroute = find.RouteResult;

        }
    }
}
