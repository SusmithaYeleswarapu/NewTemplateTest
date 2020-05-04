using System;
using System.Web.Mvc;
using CollegeWepPortal.Controllers;
using CollegeWepPortal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        Model1 db = new Model1();
        [TestMethod]
        public void TestMethod1()
        {
            STUDENTsController ct = new STUDENTsController();

            var result = ct.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
           
        }

        //[TestMethod]
        //public void TestMethod2()
        //{
        //    STUDENTsController ct = new STUDENTsController();
        //    ActionResult result = ct.History();
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //}
    }
}
