using System;
using Microsoft.AspNetCore.Mvc;

namespace DotnetcoreWebapiAng.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}