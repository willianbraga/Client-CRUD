using System.Collections.Generic;
using CRUD.Domain.Entities.Client;
using CRUD.Domain.Infra.Contexts;
using CRUD.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Domain.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(ClientItem client)
        {
            _context.Add(client);
            _context.SaveChanges();
        }

        public IEnumerable<ClientItem> GetAll()
        {
            return _context.Clients
                .AsNoTracking();
        }
    }
}