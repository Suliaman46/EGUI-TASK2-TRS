using Microsoft.AspNetCore.Mvc;
using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure;
using System;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Controllers
{
    public class AddEntryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEntry(string date, string code, string time, string description)
        {
            DataBase.Instance.AddEntry(date, code, Int32.Parse(time), description);
            //string debugString = "0; URL=https://localhost:7256/DailyEntriesTable/ShowTable?dateString=" + date;
            //string quote = "\"";
            //ViewData["redirect"] = System.Web.HttpUtility.HtmlEncode(quote+"0; URL=https://localhost:7256/DailyEntriesTable/ShowTable?dateString=" + date + quote);
            return View();
        }
    }
}
