using CRUD.Domain.Entities.Client;
using CRUD.Domain.Entities.Generics;
using CRUD.Domain.Repositories;
using CRUD.Domain.Utils.Commands;
using CRUD.Domain.Utils.Validations;

namespace CRUD.Domain.Handlers.Contracts
{
    public class ClientHandler : Notifiable, IHandler<CreateClient>, IHandler<UpdateClient>
    {
        private static string ERROR_MESSAGE = "Opa, temos um erro aqui, por favor verifique os parametros informados.";
        private static string SUCESS_MESSAGE = "Procedimento efetuado com sucesso.";

        private readonly IClientRepository _repository;

        public ClientHandler(IClientRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateClient command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericResult(ERROR_MESSAGE, false, command.Notifications);

            var client = new ClientItem(command.Name, command.Email, command.Phone, command.BirthDate);

            _repository.Create(client);

            return new GenericResult(SUCESS_MESSAGE, true, client);
        }

        public ICommandResult Handle(UpdateClient command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericResult(ERROR_MESSAGE, false, command.Notifications);


            var client = _repository.GetById(command.Id);

            client.UpdateClient(command);

            _repository.Update(client);

            return new GenericResult(SUCESS_MESSAGE, true, client);
        }
    }
}