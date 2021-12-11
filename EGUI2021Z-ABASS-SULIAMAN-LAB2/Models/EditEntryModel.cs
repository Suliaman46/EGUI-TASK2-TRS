using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure;
namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Models
{
    public class EditEntryModel
    {
        public string date { get; set; }

        public string code { get; set; }

        public int time { get; set; }

        public string description { get; set; }

        public int count { get;  set; }
        public EditEntryModel(string date, string code, int time, string decription, int count)
        {
            this.date = date;
            this.code = code;
            this.time = time;
            this.description = decription;
            this.count = count;
        }







    }
}
