using Newtonsoft.Json;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public class Entry
    {
        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("time")]
        public int time { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        public Entry()
        {

        }
        public Entry(string date, string code, int time, string description)
        {
            this.date = date;
            this.code = code;
            this.time = time;
            this.description = description;
        }
    }
}
