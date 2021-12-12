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

        public List<string> GetCodeList()
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

            return null;
        }

        public void AddActivity(string code, string name, string manager, bool active, int budget)
        {
            Activity toAdd = new Activity(code, name,  manager, active, budget);
            activities.Add(toAdd);
        }

        public List<string> GetProjectDetails(string code)
        {
            List<string> toReturn = new();
            foreach(Activity activity in activities)
            {
                if(activity.code == code)
                {
                    toReturn.Add(activity.name);
                    toReturn.Add(activity.manager);
                    toReturn.Add(activity.budget.ToString());
                    toReturn.Add(activity.active.ToString());
                    break;

                }
            }
            return toReturn;


        }
    }
}
