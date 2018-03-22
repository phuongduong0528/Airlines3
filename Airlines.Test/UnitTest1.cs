using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Airlines.Business.Manager;
using Airlines.FormApplication.Controller;
using Airlines.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airlines.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BookFlightManager bookFlightManager = new BookFlightManager();
            
            List<int[]> list1 = bookFlightManager.FindFlight("AUH", "CAI", new DateTime(2017, 10, 7));
            List<int[]> list2 = bookFlightManager.FindFlight("AUH", "CAI", new DateTime(2017, 10, 8));

            List<int[]> list3 = list1.Union(list2).ToList();
            var x = list3.Distinct();
        }
    }
}
