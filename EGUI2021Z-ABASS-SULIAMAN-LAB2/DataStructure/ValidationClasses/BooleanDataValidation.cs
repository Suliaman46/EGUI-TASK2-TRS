using System.ComponentModel.DataAnnotations;

namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]

    public class BooleanDataValidation : ValidationAttribute
    {
        public string message = "Accepted values are only true or false";



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Console.WriteLine(value.ToString());
            if (value != null)
            {
                if (value is bool)
                {
                    return ValidationResult.Success;

                }
                else
                    return new ValidationResult(message);


            }
            return new ValidationResult(message);

        }
    }
}

