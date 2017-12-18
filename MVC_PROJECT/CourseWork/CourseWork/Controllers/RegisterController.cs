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
        List<Author> Auth1 = new List<Author>();
        List<FullReg_animal> regAnimal1 = new List<FullReg_animal>();
        public string authorId;
       public string RegAuthorId;
        Registration_author MyRerAuthor = new Registration_author();
        // GET: Register
        public ActionResult Index()
        {
            Auth1 = author.GetAllAuthors();
            regAnimal1 = reg_animal.GetAllReg_animals();
            foreach (FullReg_animal i in regAnimal1)
            {
                foreach (Author j in Auth1)
                {
                    if (i.Author_name == j.Id)
                        i.Author_name = j.Author_name;
                }
            }
            ViewBag.Methods = method.GetAllMethods();
            ViewBag.Reg_author = reg_author.GetAllReg_author();
            ViewBag.Reg_animal = regAnimal1;
            return View();
        }

        public ActionResult DiscardRegAnimal(string id)
        {
            //reg_animal.DeleteRegAnimal(id);
            return RedirectToAction("Index", "Register");
        }
        public ActionResult DiscardRegAuthor(string id)
        {
          //  reg_author.DeleteReg_author(id);
            return RedirectToAction("Index", "Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRegister(RegAddAuthorViewModel model)
        {

            if (author.AuthorByName(model.Author)== null)
            {
                TempData["message"] = $"Автора с таким именем не существует!";
            }
            else  if (ModelState.IsValid)
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
            if (method.GetMethodById(model.Method) == null)
            {
                TempData["message"] = $"Метода с таким ID не существует!";
            }
            else if (coord.GetCoordinateById(model.Coords) == null)
            {
                TempData["message"] = $"Местоположения с таким ID не существует!";
            }
            else if (animal.GetAnimalByName(model.Animal) == null)
            {
                TempData["message"] = $"Животного с таким именем не существует!";
            }
            else if (reg_author.GetReg_authorById(model.RegAuthor) == null)
            {
                TempData["message"] = $"Регистрации автора с таким Id не существует!";
            }
            else if (ModelState.IsValid)
            {
                string Id = Guid.NewGuid().ToString();
                reg_animal.CreateRegAnimal(Id,model.Animal,model.RegAuthor,model.Coords,model.Method);

                TempData["added"] = $"Учёт животного успешно создан";

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
    }
}