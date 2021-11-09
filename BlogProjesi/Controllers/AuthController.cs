using BlogProjesi.Models.data;
using BlogProjesi.Models.entity;
using BlogProjesi.Models.ViewModels.Auth.Login;
using BlogProjesi.Models.ViewModels.Auth.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjesi.Controllers
{
    public class AuthController : Controller
    {
        private readonly UygulamaDbContext _db;

        public AuthController(UygulamaDbContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult Login(LoginViewModel loginViewModel) 
        {
            if (ModelState.IsValid)
            {
                if (_db.Users.Any(x => x.UserName == loginViewModel.UserName && x.Password == loginViewModel.Password))
                {
                    HttpContext.Session.SetString("user", loginViewModel.UserName);
                    return RedirectToAction("Index", "Home");
                }              
                
            }
            ModelState.AddModelError("", "Bilgilerde hata var.");
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bilgilerde bir hata var. Lütfen kontrol ediniz.");
                return View();
            }

            if (_db.Users.Any(x=> x.UserName == registerViewModel.UserName))
            {
                ModelState.AddModelError("", "Bu kullanıcı adı kullanımda");
                return View();
            }
            _db.Users.Add(new Models.entity.User { UserName = registerViewModel.UserName, Password = registerViewModel.Password });
            _db.SaveChanges();
            TempData["message"] = "Başarıyla kayıt olundu";
            return RedirectToAction("Login", "Auth");
        }
    }
}
