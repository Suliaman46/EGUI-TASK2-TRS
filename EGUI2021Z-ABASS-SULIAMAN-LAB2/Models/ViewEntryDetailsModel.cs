namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Models
{
    public class ViewEntryDetailsModel
    {
        public string date { get; set; }

        public string code { get; set; }

        public int time { get; set; }

        public string description { get; set; }

        public string projectName { get; set; }
        public string projectManager { get; set; }
        public int projectBudget { get; set; }

        public string projectActive{ get; set; }
        public ViewEntryDetailsModel(string date, string code, int time, string description,string projectName,string projectManager,int projectBudget,string active)
        {
            this.date = date;
            this.code = code;
            this.time = time;
            this.description = description;
            this.projectName = projectName;
            this.projectManager = projectManager;
            this.projectBudget = projectBudget;
            this.projectActive = active;
        }
    }
}
