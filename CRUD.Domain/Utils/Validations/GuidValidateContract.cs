using System;
namespace CRUD.Domain.Utils.Validations
{
    public partial class ValidateContract : Notifiable
    {
        public ValidateContract IsEmpty(Guid value, string property, string message)
        {
            if (value == Guid.Empty)
                AddNotification(property, message);

            return this;
        }
    }
}