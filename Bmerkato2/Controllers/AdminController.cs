﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Bmerkato2.Controllers
{
  
    public class AdminController : Controller
    {
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
