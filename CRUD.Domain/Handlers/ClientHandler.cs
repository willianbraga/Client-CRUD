using CRUD.Domain.Entities.Client;
using CRUD.Domain.Entities.Generics;
using CRUD.Domain.Repositories;
using CRUD.Domain.Utils.Commands;
using CRUD.Domain.Utils.Validations;

namespace CRUD.Domain.Handlers.Contracts
{
    public class ClientHandler : Notifiable, IHandler<CreateClient>
    {
        private readonly IClientRepository _repository;

        public ClientHandler(IClientRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateClient command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericResult("Opa, temos um erro aqui, por favor verifique os parametros informados.", false, command.Notifications);

            var client = new ClientItem(command.Name, command.Email, command.Phone, command.BirthDate);

            _repository.Create(client);

            return new GenericResult("Salvo com sucesso", true, client);
        }
    }
}