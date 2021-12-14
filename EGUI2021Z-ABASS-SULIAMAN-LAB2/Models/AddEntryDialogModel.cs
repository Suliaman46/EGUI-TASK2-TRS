using System;
using System.ComponentModel.DataAnnotations;
using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure;
namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Models
{
    public class AddEntryDialogModel
    {
        
        public DateTime date { get; set; }

        [StringLength(15, MinimumLength =1)]
        [Required]
        public string code { get; set; }

        [Required]
        [Range(1, 1440,ErrorMessage=" Time should be atleast 1 and maximum of 1440")]
        public int time { get; set; }
        public string? description { get; set; }

        public void AddEntry()
        {
            DataBase.Instance.AddEntry(date.ToString("yyyy-MM-dd"), code, time, description);
        }
    }
}
