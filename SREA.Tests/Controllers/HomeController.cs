using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SREA.Controllers
{
    [TestClass]
    public class HomeController : Controller
    {
        [TestMethod]
        public ActionResult Index()
        {
            return View();
        }

        [TestMethod]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [TestMethod]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}