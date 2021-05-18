using CRUD.Domain.Entities.Client;
using CRUD.Domain.Infra.Contexts;
using CRUD.Domain.Repositories;

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
    }
}