using ABTestTaskAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ABTestTaskAPI.ValidationAttributes
{
    public class UserRegistationDateValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            User user = (User)value;
            var RegistrationDate = DateTime.Parse(value.ToString());
            if (RegistrationDate < DateTime.Now.AddYears(-20))
            {
                ErrorMessage = $"Пользователь с {user.Id} слишком старый";
                return false;
            }
            return true;
        }
    }
}
