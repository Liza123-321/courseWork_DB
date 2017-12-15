using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseWork.Helpers;

namespace CourseWork.Controllers
{
    public class RegisterController : Controller
    {
        RegistrationAnimalHelper reg_animal = new RegistrationAnimalHelper();
        // GET: Register
        public ActionResult Index()
        {
            ViewBag.Reg_animal = reg_animal.GetAllReg_animals();
            return View();
        }

        public ActionResult AddRegister()
        {
            return View();
        }
        public ActionResult DeleteRegister()
        {
            return View();
        }
    }
}