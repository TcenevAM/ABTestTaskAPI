using ABTestTaskAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

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
                ErrorMessage = $"Пользователь с {user.id} слишком старый";
                return false;
            }
            return true;
        }
    }
}
