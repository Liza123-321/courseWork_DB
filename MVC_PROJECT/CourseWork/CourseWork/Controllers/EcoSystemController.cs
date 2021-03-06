﻿using System;
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
    public class EcoSystemController : Controller
    {
        private EcosystemHelper ecosystem= new EcosystemHelper();
        private CoordinateHelper coord = new CoordinateHelper();

        // GET: EcoSystem
        public ActionResult Index()
        {
            List<Ecosystem> ecosystem1 = ecosystem.GetAllEcosystems();
            List<CoordinatesRe> coord1 = coord.GetAllCoordinatesRe();
            foreach (Ecosystem i in ecosystem1)
            {
                foreach (CoordinatesRe j in coord1)
                {
                    if (i.Coordinates == j.Id)
                        i.Coordinates = j.Coord;
                }
            }
            ViewBag.Ecosystem = ecosystem1;
             
            ViewBag.CoordRe = coord.GetAllCoordinatesRe();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddEcosystem(EcosystemViewModels model)
        {
            if (ecosystem.GetEcosystemByName(model.Ecosystem_name) != null)
            {
                TempData["message"] = $"Экосистема с таким именем уже существует!";
            }
            else if (coord.GetCoordinateById(model.Coordinates) == null)
            {
                TempData["message"] = $"Местоположения с таким ID не существует!";
            }
            else if (ModelState.IsValid)
            {
                string Id = Guid.NewGuid().ToString();
                ecosystem.CreateEcosystem(Id, model.Ecosystem_name,model.Bitope,model.Coordinates);

                TempData["message"] = $"Экосистема успешно создана";
                TempData["added"] = $"Экосистема успешно создана";
                //     return RedirectToAction("Index", "Detachment");

            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteEcosystem(DetachmentViewModels model)
        {
            try
            {
                string Id = ecosystem.GetEcosystemByName(model.Detachment_name).Id;
                if (ModelState.IsValid)
                {
                    ecosystem.DeleteEcosystem(Id);

                    TempData["message"] = $"Экосистема успешно удалёна";
                    //     return RedirectToAction("Index", "Detachment");

                }
            }
            catch (Exception e) { TempData["message"] = $"Экосистемы с таким именем не существует"; }

            return View(model);
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