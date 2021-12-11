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
        
        public void write(string filePath)
        {
            string fileName = "kowalski-2021-11.json";
            string jsonFilePath = filePath + @"\" + fileName;
            foreach(Month report in monthlyReports)
            {
                string json = JsonConvert.SerializeObject(report, Formatting.Indented);
                File.WriteAllText(jsonFilePath, json);

            }
        }
        public List<Entry> GetEntries()
        {
            foreach (Month report in monthlyReports)
            {
                // if report.monthYear == session.monthYear then
                if (report.monthYear == SessionUser.Instance.date)
                {
                    return report.Entries;
                }

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
                    return;
                }
            }
            
            //IF FIRST ENTRY OF MONTH
            Month monthToAdd = new Month();
            monthToAdd.monthYear = date.Remove(7);
            monthToAdd.AddEntry(date, code, time, description);
            monthlyReports.Add(monthToAdd);
        }


        public Entry GetEntry(int count)
        {
            foreach (Month report in monthlyReports)
            {
                if(report.monthYear == SessionUser.Instance.date)
                {
                    int i = 0;
                    foreach (Entry entry in report.Entries)
                    {
                        if(i==count)
                        {
                            return entry;
                        }
                        i++;
                    }
                }

            }

            return null;
        }
    }
}
