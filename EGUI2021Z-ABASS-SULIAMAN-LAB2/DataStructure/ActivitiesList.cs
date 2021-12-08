using Newtonsoft.Json;
namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public class ActivitiesList
    {
        [JsonProperty("activities")]
        public List<Activity> activities { get; set; } = new();
        public List<string> Print()
        {
            List<string> toReturn = new List<string>();
            if (activities != null)
            {
                foreach (Activity activity in activities)
                {
                    toReturn.Add(activity.code);
                }

                return toReturn;
            }

            return toReturn;
        }
    }
}
