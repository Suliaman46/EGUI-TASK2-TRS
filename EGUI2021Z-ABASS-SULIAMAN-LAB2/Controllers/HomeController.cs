using EGUI2021Z_ABASS_SULIAMAN_LAB2.Models;
using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Controllers
{
    // TODO DropDown in Edit and Add Entry // DONE
    // TODO Data validation for ADD Activity, Add Entry, Edit Entry
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Welcome(string userName)
        {
            string filePath = @"C:\Users\Suliaman\source\repos\EGUI2021Z-ABASS-SULIAMAN-LAB2\EGUI2021Z-ABASS-SULIAMAN-LAB2\JsonFiles";
            SessionUser sessionUser = SessionUser.Instance;
            sessionUser.userName = userName;
            sessionUser.date = DateTime.Now;
            DataBase DB = DataBase.Instance;
            DB.pathToJsonDirectory = filePath;
            DB.LoadFromJson();
            ViewData["date"] = DateTime.Now.ToString("dd MMMM yyyy");
            DailyEntriesTableModel dailyEntriesTableModel = new DailyEntriesTableModel(DateTime.Now.ToString("yyyy-MM-dd"));
            return View(dailyEntriesTableModel);
        }
        [HttpGet]
        public IActionResult Welcome(DateTime Displaydate, int deb = 0)
        {
            if(Displaydate == DateTime.MinValue)
            {
                Displaydate = DateTime.Now;
            }
            SessionUser.Instance.date = Displaydate;
            ViewData["date"] = Displaydate.ToString("dd MMMM yyyy");
            DailyEntriesTableModel dailyEntriesTableModel = new DailyEntriesTableModel(Displaydate.ToString("yyyy-MM-dd"));
            //return View(dailyEntriesTableModel.Entries);
            return View(dailyEntriesTableModel);
        }

        public IActionResult AddEntryDialog()
        {
            ViewData["date"] = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.codeList = DataBase.Instance.GetCodeList();
            return View();
        }

        public IActionResult AddEntry(DateTime DisplayDate, string code, string time, string description)
        {
            DataBase.Instance.AddEntry(DisplayDate.ToString("yyyy-MM-dd"), code, Int32.Parse(time), description);
            return RedirectToAction(actionName: "Welcome", controllerName: "Home", new
            {
                DisplayDate = DisplayDate.ToString("yyyy-MM-dd"),
                deb = 0,
            });
        }

        public IActionResult AddActivityDialog()
        {

            return View();
        }

        public IActionResult AddActivity(string code,string name, string manager, string active, string budget)
        {
            DataBase.Instance.AddActivity(code,name,manager,System.Convert.ToBoolean(active),Int32.Parse(budget));
            return RedirectToAction(actionName: "Welcome", controllerName: "Home", new
            {
                DisplayDate = SessionUser.Instance.date.ToString("yyyy-MM-dd"),
                deb = 0,
            });
        }

        [HttpGet]
        public IActionResult EditEntryDialog(int id)
        {
            if (DataBase.Instance.GetEntry(id) != null)
            {
                Entry entryToEdit = DataBase.Instance.GetEntry(id);
                EditEntryModel model = new EditEntryModel(entryToEdit.date, entryToEdit.code, entryToEdit.time, entryToEdit.description, id);
                if(DataBase.Instance.GetCodeList != null)
                {
                    model.codeList = DataBase.Instance.GetCodeList();
                }
                return View(model);
        }
            return View();
    }

        public IActionResult EditEntry(string code, string time, string description, string count, string date)
        {
            int temp = Int32.Parse(count);

            //if (DataBase.Instance.GetEntry(temp) != null)
            //{
                //Entry entryToEdit = DataBase.Instance.GetEntry(temp);
                //EditEntryModel model = new EditEntryModel(entryToEdit.date, entryToEdit.code, entryToEdit.time, entryToEdit.description);
                //return View(model);
                DataBase.Instance.EditEntry(code,Int32.Parse(time),description,temp); 
            //}
            return RedirectToAction(actionName: "Welcome", controllerName: "Home", new
            {
                DisplayDate = date,
                deb = 0,
            });
        }

        public IActionResult DeleteEntry(int id)
        {
            DataBase.Instance.DeleteEntry(id);
            return RedirectToAction(actionName: "Welcome", controllerName: "Home", new
            {
                DisplayDate = SessionUser.Instance.date.ToString("yyyy-MM-dd"),
                deb = 0,
            });
        }

        public IActionResult ViewEntryDetails(int id)
        {
            Entry entry = DataBase.Instance.GetEntry(id);
            if(entry != null)
            {
                List<string> paramList = DataBase.Instance.GetProjectDetails(entry.code);
                ViewEntryDetailsModel model = new ViewEntryDetailsModel(entry.date, entry.code, entry.time, entry.description, paramList[0], paramList[1], Int32.Parse(paramList[2]), paramList[3]);
                return View(model);
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult MonthlyReport(DateTime DisplayDate)
        {
            if (DisplayDate == DateTime.MinValue)
            {
                DisplayDate = DateTime.Now;
            }
            SessionUser.Instance.date = DisplayDate;
            ViewData["date"] = DisplayDate.ToString("MMMM yyyy");
            MonthlyEntriesTableModel monthlyEntriesTableModel = new MonthlyEntriesTableModel(DisplayDate.ToString("yyyy-MM"));
            return View(monthlyEntriesTableModel);
        }
        public IActionResult Save()
        {
            DataBase.Instance.SaveToJson();
            return RedirectToAction(actionName: "Welcome", controllerName: "Home", new
            {
                DisplayDate = DateTime.Now.ToString("yyyy-MM-dd"),
                deb = 0,
            });
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

        public void test(string selVal)
        {
            return;
        }

        public IActionResult DropDownTest()
        {
            return View();
        }

    }
}