using ABTestTaskAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ABTestTaskAPI.ValidationAttributes
{
    public class UserDatasValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            User user = (User)value;
            var LastActivityDate = DateTime.Parse(user.LastActivityDate.ToString());
            var RegistrationDate = DateTime.Parse(user.RegistrationDate.ToString());
            if (user.LastActivityDate < user.RegistrationDate)
            {
                ErrorMessage = $"У пользователя с Id {user.Id} дата последней активности меньше даты регистрации";
                return false;
            }
            if (LastActivityDate > DateTime.Now)
            {
                ErrorMessage = $"Некорректное значение даты последней активности у пользователя с id {user.Id}";
                return false;
            }
            if (RegistrationDate < DateTime.Now.AddYears(-20))
            {
                ErrorMessage = $"Пользователь с {user.Id} слишком старый";
                return false;
            }
            return true;
        }
    }
}
