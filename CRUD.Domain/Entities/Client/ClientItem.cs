using System;

namespace CRUD.Domain.Entities.Client
{
    public class ClientItem : Entity
    {
        public ClientItem(string name, string email, string phone, DateTime birthDate)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.BirthDate = birthDate;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public void UpdateClient(UpdateClient clientItem)
        {
            this.Name = clientItem.Name;
            this.Email = clientItem.Email;
            this.Phone = clientItem.Phone;
            this.BirthDate = clientItem.BirthDate;
        }

    }
}