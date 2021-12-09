using Newtonsoft.Json;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public class Month
    {   
        [JsonProperty("entries")]
        List<Entry> entries = new();

        public List<Entry> Entries { get { return entries; } }
        public string monthYear { get; set; }

        public void AddEntry(string date, string code, int time, string description)
        {
            Entry toAdd = new Entry(date,code,time,description);
            entries.Add(toAdd);
        }


    }
}
