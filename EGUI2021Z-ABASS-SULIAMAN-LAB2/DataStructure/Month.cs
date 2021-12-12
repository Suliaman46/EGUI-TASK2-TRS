using Newtonsoft.Json;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public class Month
    {
        [JsonIgnoreAttribute]
        List<Entry> entries = new();
        [JsonProperty("entries")]
        public List<Entry> Entries { get { return entries; } }

        [JsonIgnoreAttribute]
        public string monthYear { get; set; }

        public void AddEntry(string date, string code, int time, string description)
        {
            Entry toAdd = new Entry(date,code,time,description);
            entries.Add(toAdd);
        }

 
        public void DeleteEntry(int id)
        {
            int countMonthly = 0;
            int count = 0;
            foreach (Entry entry in entries)
            {
                if (entry.date == SessionUser.Instance.date.ToString("yyyy-MM-dd"))
                {
                    if (count == id)
                    {
                        break;
                    }
                    count++;
                }
                countMonthly++;
            }
            entries.RemoveAt(countMonthly);

        }

    }
}
