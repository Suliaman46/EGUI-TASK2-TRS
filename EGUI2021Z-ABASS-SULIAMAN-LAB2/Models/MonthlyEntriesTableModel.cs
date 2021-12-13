using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Models
{
    public class MonthlyEntriesTableModel : DailyEntriesTableModel
    {
        public MonthlyEntriesTableModel(string monthYear)
        {
            totalTime = 0;
            AddData(monthYear);
        }
        protected override void AddData(string dateString)
        {
            if (DataBase.Instance.GetEntries() != null)
            {
                foreach (Entry entry in DataBase.Instance.GetEntries())
                {
                    
                    var toAdd = new DailyEntriesTableDB(entry.date, entry.code, entry.time, entry.description);
                    totalTime += toAdd.time;
                    entries.Add(toAdd);

                }
            }


        }

    }
}
