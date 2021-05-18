namespace CRUD.Domain.Utils.Validations
{
    public partial class ValidateContract
    {
        public ValidateContract IsNullOrEmpty(string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value))
                AddNotification(property, message);

            return this;
        }

        public ValidateContract HasMinLen(string value, int size, string property, string message)
        {
            if (value.Length <= size)
                AddNotification(property, message);

            return this;
        }
        public ValidateContract HasMaxLen(string value, int size, string property, string message)
        {
            if (value.Length > size)
                AddNotification(property, message);

            return this;
        }
    }
}