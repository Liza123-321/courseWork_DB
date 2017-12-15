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
        private SuborderHelper suborder = new SuborderHelper();
        private AnimalHelper animal = new AnimalHelper();
        // GET: Detachment
        public ActionResult Index()
        {
            ViewBag.Detachment = detach.GetAllDetachments();
            ViewBag.Species = species.GetAllSpecies();
            ViewBag.Suborder = suborder.GetAllSuborder();
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
               //     return RedirectToAction("Index", "Detachment");
                
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
            else if (suborder.GetSuborderByName(model.Suborder) == null)
            {
                TempData["message"] = $"Подотряда с таким именем не существует!";
            }
           else if (ModelState.IsValid)
            {
                string Id = Guid.NewGuid().ToString();
                species.CreateSpecies(Id, model.Suborder,model.Species_name_RUS,model.Species_name_ENG);

                TempData["message"] = $"Вид успешно создан";
              //  return RedirectToAction("Index", "Detachment");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSuborder(SuborderViewModels model)
        {
            if (suborder.GetSuborderByName(model.Suborder_name) != null)
            {
                TempData["message"] = $"Подотряд с таким именем уже существует!";
            }
            else if (detach.GetDetachmentByName(model.Detachment) == null)
            {
                TempData["message"] = $"Отряда с таким именем не существует!";
            }
            else if (ModelState.IsValid)
            {
                string Id = Guid.NewGuid().ToString();
                suborder.CreateSuborder(Id, model.Detachment, model.Suborder_name, Convert.ToInt32(model.Count_genus));

                TempData["message"] = $"Подотряд успешно создан";
            //    return RedirectToAction("Index", "Detachment");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteDetachment(DetachmentViewModels model)
        {
            try
            {
                string Id1 = detach.GetDetachmentByName(model.Detachment_name).Id;
                if (suborder.GetSuborderByDetach(Id1)!= null)
                {
                    TempData["message"] = $"Данный объект является частью другого объекта: " + suborder.GetSuborderByDetach(Id1).Suborder_name;
                    //return View(model);
                }
                else if (ModelState.IsValid)
                {
                    detach.DeleteDetachment(Id1);
                    TempData["message"] = $"Отряд успешно удалён";
                    //     return RedirectToAction("Index", "Detachment");

                }
            } catch(Exception e) { TempData["message"] = $"Отряда с таким именем не существует"; }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteSuborder(DetachmentViewModels model)
        {
            try
            {
                string Id = suborder.GetSuborderByName(model.Detachment_name).Id;
                if (species.GetSpeciesBySuborder(Id) != null)
                {
                    TempData["message"] = $"Данный объект является частью другого объекта: " + species.GetSpeciesBySuborder(Id).ENG_name;
                    //return View(model);
                }
                else if (ModelState.IsValid)
                {
                    suborder.DeleteSuborder(Id);

                    TempData["message"] = $"Подотряд успешно удалён";
                    //     return RedirectToAction("Index", "Detachment");

                }
            }
            catch (Exception e) { TempData["message"] = $"Подотряда с таким именем не существует"; }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteSpecies(DetachmentViewModels model)
        {
            try
            {
                string Id = species.GetSpeciesByRusName(model.Detachment_name).Id;
                if (animal.GetAnimalBySpesies(Id) != null)
                {
                    TempData["message"] = $"Данный объект является частью другого объекта: " + animal.GetAnimalBySpesies(Id).Animal_name;
                    //return View(model);
                }
                else if (ModelState.IsValid)
                {
                    species.DeleteSpecies(Id);

                    TempData["message"] = $"Вид успешно удалён";
                    //     return RedirectToAction("Index", "Detachment");

                }
            }
            catch (Exception e) { TempData["message"] = $"Вида с таким именем не существует"; }

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
        public ActionResult AddSuborder()
        {
            return View();
        }

        public ActionResult DeleteDetachment()
        {
            return View();
        }
        public ActionResult DeleteSpecies()
        {
            return View();
        }
        public ActionResult DeleteSuborder()
        {
            return View();
        }
    }
}