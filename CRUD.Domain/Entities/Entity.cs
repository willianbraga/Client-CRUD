using System;

namespace CRUD.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; private set; }
    }
}