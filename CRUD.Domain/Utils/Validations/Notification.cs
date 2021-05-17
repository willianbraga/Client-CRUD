namespace CRUD.Domain.Utils.Validations
{
    public class Notification
    {
        public string Property { get; set; }
        public string Message { get; set; }

        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}