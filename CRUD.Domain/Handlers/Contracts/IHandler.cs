using CRUD.Domain.Utils.Commands;

namespace CRUD.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}