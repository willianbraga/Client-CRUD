using System;
using System.Collections.Generic;
using CRUD.Domain.Entities.Client;
using CRUD.Domain.Repositories;

namespace CRUD.Domain.Tests.Repositories
{
    public class FakeClientRepository : IClientRepository
    {
        public void Create(ClientItem client)
        { }

        public IEnumerable<ClientItem> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ClientItem GetById(Guid id)
        {
            return new ClientItem("Willian Braga", "willian.kaeru@gmail.com", "123456789", DateTime.Now);
        }

        public void Update(ClientItem client)
        { }
    }
}