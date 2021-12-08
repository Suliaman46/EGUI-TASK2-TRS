using Newtonsoft.Json;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public class Month
    {   
        [JsonProperty("entries")]
        List<Entry> entries = new();

        public string monthYear { get; set; }
    }
}
