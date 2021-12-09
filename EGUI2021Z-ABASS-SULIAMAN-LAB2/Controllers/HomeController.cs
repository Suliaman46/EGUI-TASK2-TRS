using EGUI2021Z_ABASS_SULIAMAN_LAB2.Models;
using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string filePath = @"C:\Users\Suliaman\source\repos\EGUI2021Z-ABASS-SULIAMAN-LAB2\EGUI2021Z-ABASS-SULIAMAN-LAB2\JsonFiles";
            DataBase DB = DataBase.Instance;
            DB.LoadFromJson(filePath);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}