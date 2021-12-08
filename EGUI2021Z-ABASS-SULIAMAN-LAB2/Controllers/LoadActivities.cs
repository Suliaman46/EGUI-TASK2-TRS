using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Controllers
{
    public class LoadActivities : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string LoadJson()
        {
            string filePath = @"C:\Users\Suliaman\source\repos\EGUI2021Z-ABASS-SULIAMAN-LAB2\EGUI2021Z-ABASS-SULIAMAN-LAB2\JsonFiles";
            DataStructure.DataBase DB = new DataStructure.DataBase(filePath);


            return  String.Join(",",DB.PrintList());
        }
         
    }
}
