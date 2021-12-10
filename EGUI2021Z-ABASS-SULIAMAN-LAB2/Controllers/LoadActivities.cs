using Microsoft.AspNetCore.Mvc;
using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure;
namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Controllers
{
    public class LoadActivities : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void LoadJson()
        {
            //string filePath = @"C:\Users\Suliaman\source\repos\EGUI2021Z-ABASS-SULIAMAN-LAB2\EGUI2021Z-ABASS-SULIAMAN-LAB2\JsonFiles";
            //DataBase DB = DataBase.Instance;
            //DB.LoadFromJson(filePath);
            //return  String.Join(",",DB.PrintList());
            DataBase.Instance.SaveToJson();
            //RedirectToAction(controllerName:"Home",actionName:"Index");

        }
         
    }
}
