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
    public class RegisterController : Controller
    {
        RegistrationAnimalHelper reg_animal = new RegistrationAnimalHelper();
        RegisterationAuthorHelper reg_author = new RegisterationAuthorHelper();
        MethodHelper method = new MethodHelper();
        CoordinateHelper coord = new CoordinateHelper();
        AnimalHelper animal = new AnimalHelper();
        AuthorHelper author = new AuthorHelper();
       public string authorId;
       public string RegAuthorId;
        Registration_author MyRerAuthor = new Registration_author();
        // GET: Register
        public ActionResult Index()
        {
            ViewBag.Reg_animal = reg_animal.GetAllReg_animals();
            return View();
        }

        public ActionResult DiscardReg(string id)
        {
            TempData["message"] =id;
            reg_animal.DeleteRegAnimal(id);
            return RedirectToAction("Index", "Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRegister(RegAddAuthorViewModel model)
        {

            //if (reg_author.GetReg_authorByAuthorId(author.AuthorByName(model.Author).Id) == null)
            //{
            //    TempData["message"] = $"Автора с таким именем не существует!";
            //}
            //else 
            if (ModelState.IsValid)
            {
                string Id = Guid.NewGuid().ToString();
                reg_author.CreateReg_author(Id,Convert.ToDateTime(model.Date),model.Author);
               RegAuthorId = reg_author.GetReg_authorById(Id).Id;
                authorId = author.AuthorByName(model.Author).Id;

                TempData["added"] = $"Учёт автора успешно создан";
                //     return RedirectToAction("Index", "Detachment");

            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRegisterAnimal(RegAddAnimalViewModel model)
        {
            //if (reg_animal.GetRegAnimalByMethodId(model.Method) == null)
            //{
            //    TempData["message"] = $"Метода с таким ID не существует!";
            //}
            //else if (reg_animal.GetRegAnimalByCoordId(model.Coords) == null)
            //{
            //    TempData["message"] = $"Местоположения с таким ID не существует!";
            //}
            //else 
            if (ModelState.IsValid)
            {
                string Id = Guid.NewGuid().ToString();
                reg_animal.CreateRegAnimal(Id,model.Animal,model.RegAuthor,model.Coords,model.Method);

                TempData["added"] = $"Учёт животного успешно создан";
                //     return RedirectToAction("Index", "Detachment");

            }
            return View(model);
        }
        public ActionResult AddRegister()
        {
            return View();
        }
        public ActionResult AddRegisterAnimal()
        {
            return View();
        }
        public ActionResult DeleteRegister()
        {
            return View();
        }
    }
}