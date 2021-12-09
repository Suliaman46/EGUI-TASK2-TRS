using Newtonsoft.Json;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public sealed class DataBase
    {
        private static readonly Lazy<DataBase> lazy = new Lazy<DataBase>(() => new DataBase());

        public static DataBase Instance { get { return lazy.Value; } }
        public ActivitiesList? activitiesList { get; set; }
        public List<User> users { get; set; } = new List<User>();

        public DataBase()
        {

        }

        public DataBase(string filePath)
        {
            this.LoadFromJson(filePath);
        }

        public void LoadFromJson(string filePath)
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

        public List<Entry> GetEntries()
        {

            foreach(var user in users)
            {
                // if (user) == session user then
                return user.GetEntries();
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
        
    }
}
