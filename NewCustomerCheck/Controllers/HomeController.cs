using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NewCustomerCheck.Models;

namespace NewCustomerCheck.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewCustomerCheckContext _context;

        private readonly IConfiguration _configuration;

        public HomeController(NewCustomerCheckContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            if (!System.IO.File.Exists(Path.Combine(Environment.CurrentDirectory , "websiteconfig.json")))
            {
                ConfigSaveByJson.ConfigSaveByJson.Write<Websiteconfig>(Program.Websiteconfig,Path.Combine(Environment.CurrentDirectory, "websiteconfig.json"));
            }
            return View("Nothing");
        }

        public IActionResult Privacy()
        {
            return View("Nothing");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DataWindow()
        {
            return View("Nothing");
        }

        public string Test()
        {
            return _configuration.GetValue<string>("Test");
        }


    }
}
