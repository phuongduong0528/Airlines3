using System;
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
            findRoute.CalculatePath(2, 3, new DateTime(2017,10,23));
        }
    }
}
