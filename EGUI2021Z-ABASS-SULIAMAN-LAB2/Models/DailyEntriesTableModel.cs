using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Models
{
    public class DailyEntriesTableModel
    {
        protected List<DailyEntriesTableDB> entries = new() ;
        public int totalTime { get; set; }
        
        public List<DailyEntriesTableDB> Entries
        {
            get { return entries; }
        }

        public DailyEntriesTableModel()
        {

        }
        public DailyEntriesTableModel(string dateString)
        {
            totalTime = 0;
            AddData(dateString);
        }

        protected virtual void AddData(string dateString)
        {
            if(DataBase.Instance.GetEntries()!= null )
            {
                foreach (Entry entry in DataBase.Instance.GetEntries())
                {
                    if (entry.date == dateString)
                    {
                        var toAdd = new DailyEntriesTableDB(entry.date, entry.code, entry.time, entry.description);
                        totalTime += toAdd.time;
                        entries.Add(toAdd);
                    }

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
