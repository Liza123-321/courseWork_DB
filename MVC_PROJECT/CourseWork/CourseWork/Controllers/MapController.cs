using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CourseWork.DAL_Models;
using CourseWork.Helpers;
using CourseWork.Models;

namespace CourseWork.Controllers
{
    public class MapController : Controller
    {
        CoordinateHelper coord = new CoordinateHelper();
        JsonHelper.JsonHelper jsonHelper = new JsonHelper.JsonHelper();

        // GET: Map
        public ActionResult Index()
        {
            string text="";
            List<Coordinates> coord1 = new List<Coordinates>();
            coord1 = coord.GetAllCoordinates();
            foreach (Coordinates i in coord1)
            {
                text += i.GeoJson;
                text += ",";
            }
            jsonHelper.ToGeo(text);
            ViewBag.CoordRe = coord.GetAllCoordinatesRe();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPoint(MapViewModels model)
        {
            if (ModelState.IsValid)
            {
                string Id = Guid.NewGuid().ToString();
                coord.CreateCoordinates(Id, model.Type, model.Adress, model.Latitude.ToString(),model.Longitude.ToString());

                TempData["message"] = $"Местоположение успешно создано";
                TempData["added"] = $"Местоположение успешно создано";
                //     return RedirectToAction("Index", "Detachment");
            }
            return View(model);
        }


        public ActionResult AddPoint()
        {
            return View();
        }
    }
}