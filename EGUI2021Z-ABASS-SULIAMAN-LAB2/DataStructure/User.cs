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
            string monthYear = fileName.Remove(0, 9);
            monthYear = monthYear.Remove(7);
            Month monthToAdd = JsonConvert.DeserializeObject<Month>(File.ReadAllText(jsonFilePath));
            monthToAdd.monthYear = monthYear;
            monthlyReports.Add(monthToAdd);
        }

        public List<Entry> GetEntries()
        {
            foreach (Month report in monthlyReports)
            {
                // if report.monthYear == session.monthYear then
                return report.Entries;
            }
            return null;

        }

        public void AddEntry(string date, string code, int time, string description)
        {
            foreach(Month report in monthlyReports)
            {
                if(report.monthYear == date.Remove(7))
                {
                    report.AddEntry( date, code, time,description);
                }
            }
        }

    }
}
