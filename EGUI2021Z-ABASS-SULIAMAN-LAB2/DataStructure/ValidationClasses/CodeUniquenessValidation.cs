using System.ComponentModel.DataAnnotations;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure.ValidationClasses
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]

    public class CodeUniquenessValidation: ValidationAttribute
    {


            public string message = "Code Already Exists";
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    if(DataBase.Instance.GetCodeList().Contains(value) )
                    {
                        return new ValidationResult(message);

                    }
                }
                return new ValidationResult("Please Enter Code");

            }
        }
    
}

