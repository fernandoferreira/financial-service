using System;
using Financial.Services.OpenBank.Core.Base;

namespace Financial.Services.OpenBank.Core.Domain
{
    public class Client: EntityBase
    {
        public Client(string name, string email, decimal salary, string cpf)
        {
            Name = name;
            Email = email;
            Salary = salary;
            CPF = cpf;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; }

        public string CPF { get;  set; }

        
    }
}

