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
        string name { get; set; }
        [JsonProperty("manager")]
        string manager { get; set; }
        [JsonProperty("active")]
        bool active { get; set; }
        [JsonProperty("budget")]
        int budget { get; set; }
        List<string> subActivities { get; set; }

        public Activity(string code,string name, string manager, bool active, int budget, List<string> subActivities)
        {
            this.code = code;
            this.name = name;   
            this.manager = manager;
            this.active = active;
            this.budget = budget;
            this.subActivities = subActivities;
        }

   
    }
}
