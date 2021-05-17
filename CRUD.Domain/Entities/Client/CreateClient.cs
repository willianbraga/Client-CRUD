using System;
using CRUD.Domain.Utils.Commands;
using CRUD.Domain.Utils.Validations;

namespace CRUD.Domain.Entities.Client
{
    public class CreateClient : Notifiable, ICommand
    {
        public CreateClient() { }

        public CreateClient(string name, string email, string phone, DateTime birthDate)
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

        public void Validate()
        {
            AddNotifications(
                new ValidateContract()
                .Required()
                .HasMinLen(Name, 1, "Name", "Por favor informe seu primeiro nome.")
                .HasMaxLen(Name, 100, "Name", "Por favor informe seu primeiro nome.")
                .IsEmailOrEmpty(Email, "Email", "Por favor informe um email valido.")
            );
        }
    }
}