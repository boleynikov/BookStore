using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.OshadBank.Areas.Oshadbank.Controllers
{
    [Area("Oshadbank")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // /Oshadbank/Home/Callback
        public IActionResult Callback()
        {
            return View();
        }
    }
}
