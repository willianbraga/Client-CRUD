namespace CRUD.Domain.Utils.Validations
{
    public class Contract : Notifiable
    {
        public ValidateContract ValidateContract { get; set; }
        
        
        protected Contract()
        {
            ValidateContract = new ValidateContract();
        }

    }
}