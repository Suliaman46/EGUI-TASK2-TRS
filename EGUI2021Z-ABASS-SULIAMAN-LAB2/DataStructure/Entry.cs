using Newtonsoft.Json;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public class Entry
    {
        [JsonProperty("code")]
        public string code { get; set; }
        [JsonProperty("name")]
        string subCode { get; set; }
        [JsonProperty("manager")]
        string description { get; set; }
        [JsonProperty("date")]
        string date { get; set; }
        [JsonProperty("time")]
        int time { get; set; }
    }
}
