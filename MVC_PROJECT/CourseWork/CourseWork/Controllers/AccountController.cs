using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CourseWork.DAL_Models;
using CourseWork.Helpers;
using CourseWork.Models;

namespace CourseWork.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private AuthorHelper authorHelper;
        public const string ConnectionString = @"Data Source=.;Initial Catalog=ReliseCourse;Integrated Security=True";

        public AccountController()
        {
            authorHelper = new AuthorHelper();
        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);
            Author author = authorHelper.AuthorByName(model.Login);
            if (author == null)
            {
                TempData["message"] = $"Имя автора или пароль неверны!";
                
            }
            else if(author.Pass!= model.Password)
            {
                TempData["message"] = $"Имя автора или пароль неверны!";
            }
            else
            {
                CreateCookie(model.Login, model.Password);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (authorHelper.AuthorByName(model.Login)!=null)
            {
                TempData["message"] = $"Автор с таким именем уже существует!";
            }
          else if (ModelState.IsValid)
            {
                string Id = Guid.NewGuid().ToString();
                if (authorHelper.CreateAuthor(Id,model.Login, model.Password))
                {
                    TempData["message"] = $"Автор успешно создан";
                    return RedirectToAction("Login", "Account");
                }
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #region Helpers

        public void CreateCookie(string login, string password)
        {
            var authTicket = new FormsAuthenticationTicket(1, login, DateTime.Now,
                DateTime.Now.AddMinutes(20), false, password);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authCookie);
        }
        #endregion
    }
}