﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Web.App;
using Store.Web.Models;
using System.Diagnostics;

namespace Store.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookService bookService;
        public HomeController(ILogger<HomeController> logger, BookService bookService)
        {
            _logger = logger;
            this.bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = bookService.GetAll();

            return View(books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
