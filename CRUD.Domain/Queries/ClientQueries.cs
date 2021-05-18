using System;
using System.Linq.Expressions;
using CRUD.Domain.Entities.Client;

namespace CRUD.Domain.Queries
{
    public class ClientQueries
    {
        public static Expression<Func<ClientItem, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}