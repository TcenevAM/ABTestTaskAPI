using System;
using System.ComponentModel.DataAnnotations;

namespace ABTestTaskAPI.ValidationAttributes
{
    public class UserLastActivityDateValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var LastActivityDate = DateTime.Parse(value.ToString());
            if(LastActivityDate > DateTime.Now)
            {
                ErrorMessage = "Некорректное значение даты";
                return false;
            }
            return true;
        }
    }
}
