using Microsoft.AspNetCore.Mvc;
using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure;
using System;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Controllers
{
    public class AddEntryController : Controller
    {
        public IActionResult Index()
        {
            ViewData["currentDate"] = DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }
        [HttpPost]
        public IActionResult  AddEntry(string date, string code, string time, string description)
        {
            DataBase.Instance.AddEntry(date, code, Int32.Parse(time), description);
            return RedirectToAction(actionName:"Welcome",controllerName:"Home", new
            {
                dateString = date,
                deb = 0,
            });

            
        }
    }
}
