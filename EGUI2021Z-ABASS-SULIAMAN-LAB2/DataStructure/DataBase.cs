using Newtonsoft.Json;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public class DataBase
    {
        public ActivitiesList activitiesList { get; set; }
        public List<User> users { get; set; } = new List<User>();


        public DataBase(string filePath)
        {
            this.LoadFromJson(filePath);
        }

        private void LoadFromJson(string filePath)
        {
            activitiesList = JsonConvert.DeserializeObject<ActivitiesList>(File.ReadAllText(filePath + @"\activity.json"));

            User userToAdd = new User();
            userToAdd.Name = "kowalski";
            string test = filePath + @"\Users\" + userToAdd.Name;
            userToAdd.read(test);
            users.Add(userToAdd);
        }

        public List<string> PrintList()
        {
                return this.activitiesList.Print();

        }
        
    }
}
