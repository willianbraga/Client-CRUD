using System;
using System.Collections.Generic;
using CRUD.Domain.Entities.Client;

namespace CRUD.Domain.Repositories
{
    public interface IClientRepository
    {
        void Create(ClientItem client);
        IEnumerable<ClientItem> GetAll();
        ClientItem GetById(Guid id);
        void Update(ClientItem client);

    }
}