﻿using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}