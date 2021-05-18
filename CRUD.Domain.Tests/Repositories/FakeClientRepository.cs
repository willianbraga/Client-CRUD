using System.Collections.Generic;
using CRUD.Domain.Entities.Client;
using CRUD.Domain.Repositories;

namespace CRUD.Domain.Tests.Repositories
{
    public class FakeClientRepository : IClientRepository
    {
        public void Create(ClientItem client)
        {
        }

        public IEnumerable<ClientItem> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}