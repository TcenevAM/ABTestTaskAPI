using ABTestTaskAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ABTestTaskAPI.ValidationAttributes
{
    public class UserLastActivityDateValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            User user = (User)value;
            var LastActivityDate = DateTime.Parse(value.ToString());
            if(LastActivityDate > DateTime.Now)
            {
                ErrorMessage = $"Некорректное значение даты последней активности у пользователя с id {user.Id}";
                return false;
            }
            return true;
        }
    }
}
