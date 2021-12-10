using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Models
{
    public class DailyEntriesTableModel
    {
        List<DailyEntriesTableDB> entries = new() ;
        
        public List<DailyEntriesTableDB> Entries
        {
            get { return entries; }
        }

        public DailyEntriesTableModel(string dateString)
        {
            AddData(dateString);
        }

        private void AddData(string dateString)
        {
            foreach(Entry entry in DataBase.Instance.GetEntries())
            {
                if(entry.date == dateString)
                {
                    var toAdd = new DailyEntriesTableDB(entry.date, entry.code, entry.time, entry.description);
                    entries.Add(toAdd);
                }

            }
            
        }

    }

    public class DailyEntriesTableDB
    {
        public string date;
        public string code;
        public int time;
        public string description;

        public DailyEntriesTableDB(string date, string code, int time, string description)
        {
            this.date = date;
            this.code = code;
            this.time = time;
            this.description = description;
        }

    }

}
