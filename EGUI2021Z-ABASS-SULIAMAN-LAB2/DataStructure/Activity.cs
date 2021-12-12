using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public class Activity
    {
        [JsonProperty("code")]
        public string code { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("manager")]
        public string manager { get; set; }
        [JsonProperty("active")]
        public bool active { get; set; }
        [JsonProperty("budget")]
        public int budget { get; set; }
   
        public Activity(string code,string name, string manager, bool active, int budget)
        {
            this.code = code;
            this.name = name;   
            this.manager = manager;
            this.active = active;
            this.budget = budget;
        }

   
    }
}
