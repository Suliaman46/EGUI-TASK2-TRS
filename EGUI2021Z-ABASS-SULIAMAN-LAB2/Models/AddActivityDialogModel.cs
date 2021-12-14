using System.ComponentModel.DataAnnotations;
using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure;
using EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure.ValidationClasses;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.Models
{
    public class AddActivityDialogModel
    {
        [CodeUniquenessValidation]
        [StringLength(15, MinimumLength = 2)]
        [Required]
        public string code { get; set; }

        [StringLength(15, MinimumLength = 2)]
        [Required] 
        public string name { get; set; }

        [StringLength(15, MinimumLength = 2)]
        [Required]
        public string manager { get; set; }

        [BooleanDataValidation]
        public bool active { get; set; }
        public int budget { get; set; }

        public void AddActivity()
        {
            DataBase.Instance.AddActivity(code, name, manager, active, budget);

        }
    }
}
