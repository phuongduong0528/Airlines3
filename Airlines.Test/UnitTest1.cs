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
            FindRoute findRoute = new FindRoute();

            var x = findRoute.GetResultPaths(7, 3, new DateTime(2017, 10, 4), new DateTime(2017, 10, 28));


            findRoute = new FindRoute();
            var y = findRoute.GetResultPaths(4, 2, new DateTime(2017, 10, 4), new DateTime(2017, 10, 28));

            //string x = "3.23.2018 06:00:00";
            //var y = DateTime.ParseExact(x, "M.d.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}
