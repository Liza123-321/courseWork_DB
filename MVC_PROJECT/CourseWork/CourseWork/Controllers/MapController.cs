using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseWork.Helpers;

namespace CourseWork.Controllers
{
    public class MapController : Controller
    {
        CoordinateHelper coord = new CoordinateHelper();
        JsonHelper.JsonHelper jsonHelper = new JsonHelper.JsonHelper();
        // GET: Map
        public ActionResult Index()
        {
            ViewBag.Coord = coord.GetAllCoordinatesRe();
            jsonHelper.ToJson("D:/3 COURSE/COURSE_PET/test.json");
            return View();
        }
    }
}