using Newtonsoft.Json;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public class User
    {
        public string Name { get; set; }
        List<Month> monthlyReports = new();

        public void read(string filePath)
        {
            var jsonFiles = Directory.GetFiles(filePath,"*.json");
            if (jsonFiles.Length == 0)
            {
            }
            foreach (string jsonFilePath in jsonFiles)
            {
                string fileNametest = new DirectoryInfo(jsonFilePath).Name;
                string monthYear = fileNametest.Substring(fileNametest.Length - 12);
                monthYear = monthYear.Remove(7);
                Month monthToAdd = JsonConvert.DeserializeObject<Month>(File.ReadAllText(jsonFilePath));
                if(monthToAdd != null)
                {
                    monthToAdd.monthYear = monthYear;
                    monthlyReports.Add(monthToAdd);
                }



            }

        }
        
        public void write(string filePath)
        {
            var jsonFiles = Directory.GetFiles(filePath, "*.json");
            foreach(Month report in monthlyReports)
            {
                string fileName = this.Name + @"-"+report.monthYear+".json";
                string jsonFilePath = filePath + @"\" + fileName;
                string json = JsonConvert.SerializeObject(report, Formatting.Indented);
                File.WriteAllText(jsonFilePath, json);

            }
        }
        public List<Entry> GetEntries()
        {
            foreach (Month report in monthlyReports)
            {
                if (report.monthYear == SessionUser.Instance.date.ToString("yyyy-MM"))
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
                if(report.monthYear == SessionUser.Instance.date.ToString("yyyy-MM"))
                {
                    int i = 0;
                    foreach (Entry entry in report.Entries)
                    {
                        if(entry.date == SessionUser.Instance.date.ToString("yyyy-MM-dd"))
                        {
                            if (i == count)
                            {
                                return entry;
                            }
                            i++;
                        }

                    }
                }

            }

            return null;
        }

        public void DeleteEntry(int id)
        {
            foreach (Month report in monthlyReports)
            {
                if (report.monthYear == SessionUser.Instance.date.ToString("yyyy-MM"))
                {
                    report.DeleteEntry(id);
                }

            }
        }
    }
}
