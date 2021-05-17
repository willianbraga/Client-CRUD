using System.Text.RegularExpressions;
namespace CRUD.Domain.Utils.Validations
{
    public partial class ValidateContract : Notifiable
    {
        private static string emailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public ValidateContract IsEmailOrEmpty(string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value))
                AddNotification(property, message);

            IsEmail(value, property, message);

            return this;
        }

        private ValidateContract IsEmail(string value, string property, string message)
        {
            if (!Regex.IsMatch(value ?? "", emailRegex))
                AddNotification(property, message);
            return this;
        }
    }
}