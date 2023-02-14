using System;
using Financial.Services.OpenBank.Core.Domain;

namespace Financial.Services.Application.InputModels
{
    public class ClientInputModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; }

        public string CPF { get; set; }
                
        public  Client ToEntity()
            => new Client(Name, Email, Salary, CPF);
        
    }
}

