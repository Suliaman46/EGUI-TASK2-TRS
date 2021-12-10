using Newtonsoft.Json;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public sealed class DataBase
    {
        private static readonly Lazy<DataBase> lazy = new Lazy<DataBase>(() => new DataBase());

        public static DataBase Instance { get { return lazy.Value; } }
        public ActivitiesList? activitiesList { get; set; }
        public List<User> users { get; set; } = new List<User>();
        public string sessionUserName { get; set; }
        public string pathToJsonDirectory { get; set; }
        public DataBase()
        {

        }


        public void LoadFromJson()
        {
            activitiesList = JsonConvert.DeserializeObject<ActivitiesList>(File.ReadAllText(pathToJsonDirectory + @"\activity.json"));

            User userToAdd = new User();
            userToAdd.Name = "kowalski";
            string test = pathToJsonDirectory + @"\Users\" + userToAdd.Name;
            userToAdd.read(test);
            users.Add(userToAdd);
        }

        public void SaveToJson()
        {
            string json = JsonConvert.SerializeObject(activitiesList, Formatting.Indented);
            File.WriteAllText(pathToJsonDirectory + @"\activity.json",json);

            foreach(User user in users)
            {
                user.write(pathToJsonDirectory + @"\Users\" + user.Name);
            }
            
        }

        public List<string> PrintList()
        {
                return this.activitiesList.Print();

        }

        public List<Entry> GetEntries()
        {

            foreach(var user in users)
            {
                if(user.Name == DataBase.Instance.sessionUserName)
                {
                    return user.GetEntries();
                }
            }

            return null;
        }

        public void AddEntry(string date, string code, int time, string description)
        {
            // for user in users
            // if user.name == sessionuser.name
            foreach(User user in users)
            {
                user.AddEntry(date, code, time, description);
            }
        }

        public 
        
    }
}
