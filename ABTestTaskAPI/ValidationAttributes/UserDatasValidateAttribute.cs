using ABTestTaskAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ABTestTaskAPI.ValidationAttributes
{
    public class UserDatasValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            User user = (User)value;
            if (user.LastActivityDate < user.RegistrationDate)
            {
                ErrorMessage = $"У пользователя с Id {user.Id} дата последней активности меньше даты регистрации";
                return false;
            }
            return true;
        }
    }
}
