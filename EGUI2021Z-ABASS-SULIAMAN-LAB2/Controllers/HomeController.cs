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
            //string filePath = @"C:\Users\Suliaman\source\repos\EGUI2021Z-ABASS-SULIAMAN-LAB2\EGUI2021Z-ABASS-SULIAMAN-LAB2\JsonFiles";
            //DataBase DB = DataBase.Instance;
            //DB.LoadFromJson(filePath);
            return View();
        }

        [HttpPost]
        public IActionResult Welcome(string userName)
        {
            string filePath = @"C:\Users\Suliaman\source\repos\EGUI2021Z-ABASS-SULIAMAN-LAB2\EGUI2021Z-ABASS-SULIAMAN-LAB2\JsonFiles";
            DataBase DB = DataBase.Instance;
            DB.pathToJsonDirectory = filePath;
            DB.LoadFromJson();
            //DB.sessionUserName = userName;
            SessionUser sessionUser = SessionUser.Instance;
            sessionUser.userName = userName;
            sessionUser.date = DateTime.Now.ToString("yyyy-MM");
            DailyEntriesTableModel dailyEntriesTableModel = new DailyEntriesTableModel(DateTime.Now.ToString("yyyy-MM-dd"));
            return View(dailyEntriesTableModel.Entries);
        }
        [HttpGet]
        public IActionResult Welcome(DateTime Displaydate, int deb = 0)
        {
            SessionUser.Instance.date = Displaydate.ToString("yyyy-MM");
            DailyEntriesTableModel dailyEntriesTableModel = new DailyEntriesTableModel(Displaydate.ToString("yyyy-MM-dd"));
            return View(dailyEntriesTableModel.Entries);
        }

        [HttpGet]
        public IActionResult TestEdit(int id)
        {
            if(DataBase.Instance.GetEntry(id) != null)
            {
                Entry entryToEdit = DataBase.Instance.GetEntry(id);
                EditEntryModel model = new EditEntryModel(entryToEdit.date, entryToEdit.code, entryToEdit.time, entryToEdit.description, id);
                return View(model);
            }
            return View();
        }

        public IActionResult TestEditEntry(string code, string time, string description, string count)
        {
            int temp = Int32.Parse(count);

            if (DataBase.Instance.GetEntry(temp) != null)
            {
                //Entry entryToEdit = DataBase.Instance.GetEntry(temp);
                //EditEntryModel model = new EditEntryModel(entryToEdit.date, entryToEdit.code, entryToEdit.time, entryToEdit.description);
                //return View(model);
                DataBase.Instance.EditEntry(code,Int32.Parse(time),description,temp); 
            }
            return RedirectToAction(actionName: "Welcome", controllerName: "Home", new
            {
                DisplayDate = DataBase.Instance.GetEntry(temp).date,
                deb = 0,
            });
        }


        [HttpGet]
        public IActionResult Edit(string ? description)
        {
            // TODO :: From  https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/controller-methods-views?view=aspnetcore-6.0
            //return View(DataBase.Instance.getEntry(description));
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