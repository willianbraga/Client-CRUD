using CRUD.Domain.Entities.Client;

namespace CRUD.Domain.Repositories
{
    public interface IClientRepository
    {
        void Create(ClientItem client);

    }
}