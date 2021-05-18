using System;
using CRUD.Domain.Utils.Commands;
using CRUD.Domain.Utils.Validations;

namespace CRUD.Domain.Entities.Client
{
    public class DeleteClient : Notifiable, ICommand
    {
        public DeleteClient() { }

        public DeleteClient(Guid id)
        {
            this.Id = id;

        }
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                  new ValidateContract()
                  .Required()
                  .IsEmpty(Id, "Id", "Necessario informar um Id valido.")
              );
        }
    }
}