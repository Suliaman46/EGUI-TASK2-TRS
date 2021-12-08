using Newtonsoft.Json;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public class User
    {
        public string Name { get; set; }
        List<Month> monthlyReports = new();

        public void read(string filePath)
        {
            string fileName = "kowalski-2021-11.json";
            string jsonFilePath = filePath + @"\" + fileName;
            Month monthToAdd = JsonConvert.DeserializeObject<Month>(File.ReadAllText(jsonFilePath));
            monthlyReports.Add(monthToAdd);
        }

    }
}
