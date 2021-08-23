using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ABTestTaskAPI.ValidationAttributes
{
    public class UserRegistationDateValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var RegistrationDate = DateTime.Parse(value.ToString());
            if (RegistrationDate < DateTime.Now.AddYears(-20))
            {
                ErrorMessage = "Пользователь слишком старый";
                return false;
            }
            return true;
        }
    }
}
