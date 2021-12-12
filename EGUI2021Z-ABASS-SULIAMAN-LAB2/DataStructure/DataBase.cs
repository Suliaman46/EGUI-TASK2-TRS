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
            // Reads Activities from activity.json
            activitiesList = JsonConvert.DeserializeObject<ActivitiesList>(File.ReadAllText(pathToJsonDirectory + @"\activity.json"));
            // Need to go to "pathToJsonDirectory\Users\
            //Iterate over each folder in the users folder and then do the following:
            bool sessionUserFound = false;
            var userFolders = Directory.GetDirectories(pathToJsonDirectory + @"\Users");
            if(userFolders.Length ==0)
            {
                //TODO NO USER Folder found 
                //Hence create User Folder
            }
            foreach(string userFolderName in userFolders)
            {
                
                string userName = new DirectoryInfo(userFolderName).Name;
                if (userName == SessionUser.Instance.userName)
                    sessionUserFound = true ;
                User userToAdd = new User();
                userToAdd.Name = userName;
                userToAdd.read(userFolderName);
                users.Add(userToAdd);
            }

            if(!sessionUserFound)
            {
                // If the session User does not have a folder
                string userFolder = pathToJsonDirectory + @"\Users\" + SessionUser.Instance.userName;
                Directory.CreateDirectory(userFolder);
                string userName = new DirectoryInfo(userFolder).Name;
                User userToAdd = new User();
                userToAdd.Name = userName;
                userToAdd.read(userFolder);
                users.Add(userToAdd);

            }
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
                //if(user.Name == DataBase.Instance.sessionUserName)
                if (user.Name == SessionUser.Instance.userName)

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
                if(user.Name ==SessionUser.Instance.userName)
                    user.AddEntry(date, code, time, description);
            }
        }

        public void EditEntry( string code, int time, string description, int count)
        {
            foreach (User user in users)
            {
                if(user.Name == SessionUser.Instance.userName)
                {
                    Entry toEdit = user.GetEntry(count);
                    toEdit.code = code;
                    toEdit.time = time;
                    toEdit.description = description;
                     
                    //user.GetEntry(count).time = time;
                    //user.GetEntry(count).description = description;
                }
 
            }
        }

        public void DeleteEntry(int id)
        {
            {
                foreach (User user in users)
                {
                    if (user.Name == SessionUser.Instance.userName)
                    {

                        user.DeleteEntry(id);
                        //user.GetEntry(count).time = time;
                        //user.GetEntry(count).description = description;
                    }

                }
            }
        }

        public Entry? GetEntry(int id)
        {
            foreach(User user in users)
            {
                if(user.Name == SessionUser.Instance.userName)
                {
                    return user.GetEntry(id);

                }

            }

            return null;
        }

        public List<string> GetCodeList()
        {
            List<string> toReturn = new List<string>();
            return activitiesList.GetCodeList();
        }

         public void AddActivity(string code,string name,string manager,bool active,int budget)
        {
            activitiesList.AddActivity(code, name, manager, active, budget);
        }

        public List<string> GetProjectDetails(string code)
        {
            return activitiesList.GetProjectDetails(code);
        }
        
    }
}
