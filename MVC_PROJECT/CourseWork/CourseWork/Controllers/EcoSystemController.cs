using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseWork.DAL_Models;
using CourseWork.Helpers;

namespace CourseWork.Controllers
{
    public class EcoSystemController : Controller
    {
        private EcosystemHelper ecosystem= new EcosystemHelper();

        // GET: EcoSystem
        public ActionResult Index()
        {
            ViewBag.Ecosystem = ecosystem.GetAllEcosystems();
            return View();
        }
        public ActionResult AddEcosystem()
        {
            return View();
        }
        public ActionResult DeleteEcosystem()
        {
            return View();
        }
    }
}