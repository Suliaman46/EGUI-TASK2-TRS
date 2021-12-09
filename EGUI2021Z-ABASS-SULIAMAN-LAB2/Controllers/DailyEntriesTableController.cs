using Microsoft.AspNetCore.Mvc;
using EGUI2021Z_ABASS_SULIAMAN_LAB2.Models;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Controllers
{
    public class DailyEntriesTableController : Controller
    { 

        public IActionResult Index()
        {

            //DailyEntriesTableModel dailyEntriesTableModel = new DailyEntriesTableModel();
            //return View(dailyEntriesTableModel.Entries);
            return View();
        }

        [HttpPost]
        public string myAction(string valueINeed)
        {
            
            return valueINeed;
        }

        public IActionResult ShowTable(string dateString)
        {
            DailyEntriesTableModel dailyEntriesTableModel = new DailyEntriesTableModel(dateString);
            return View(dailyEntriesTableModel.Entries);
        }

    }
}
