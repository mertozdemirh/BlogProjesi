﻿using BlogProjesi.Models.data;
using BlogProjesi.Models.entity;
using BlogProjesi.Models.ViewModels.Auth.Register;
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

        public IActionResult Login(User user) 
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            return View();
        }
    }
}
