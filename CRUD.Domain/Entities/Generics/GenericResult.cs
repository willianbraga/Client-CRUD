using CRUD.Domain.Utils.Commands;

namespace CRUD.Domain.Entities.Generics
{
    public class GenericResult : ICommandResult
    {
        public GenericResult() { }

        public GenericResult(string message, bool success, object data)
        {
            this.Message = message;
            this.Success = success;
            this.Data = data;
        }
        public string Message { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}