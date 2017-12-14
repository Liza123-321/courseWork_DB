using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CourseWork.Helpers;
using CourseWork.Models;

namespace CourseWork.Controllers
{
    public class DetachmentController : Controller
    {
        private DetachmentHelper detach = new DetachmentHelper();
        private SpeciesHelper species = new SpeciesHelper();
        // GET: Detachment
        public ActionResult Index()
        {
            ViewBag.Detachment = detach.GetAllDetachments();
            ViewBag.Species = species.GetAllSpecies();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddDetachment(DetachmentViewModels model)
        {
            if (detach.GetDetachmentByName(model.Detachment_name) != null)
            {
                TempData["message"] = $"Отряд с таким именем уже существует!";
            }
            else if (ModelState.IsValid)
            {
                string Id = Guid.NewGuid().ToString();
                detach.CreateDetachment(Id, model.Detachment_name);
                
                    TempData["message"] = $"Отряд успешно создан";
                    return RedirectToAction("Index", "Detachment");
                
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSpecies(SpeciesViewModels model)
        {
            if (species.GetSpeciesByRusName(model.Species_name_RUS) != null || species.GetSpeciesByEngName(model.Species_name_ENG) != null)
            {
                TempData["message"] = $"Вид с таким именем уже существует!";
            }
            if (ModelState.IsValid)
            {
                string Id = Guid.NewGuid().ToString();
                species.CreateSpecies(Id, model.Suborder,model.Species_name_RUS,model.Species_name_ENG);

                TempData["message"] = $"Вид успешно создан";
                return RedirectToAction("Index", "Detachment");
            }
            return View(model);
        }
        public ActionResult AddDetachment()
        {
            return View();
        }
        public ActionResult AddSpecies()
        {
            return View();
        }
    }
}