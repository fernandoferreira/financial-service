using System;
using MediatR;
using Core =  Financial.Services.OpenBank.Core.Domain;

namespace Financial.Services.Application.Commands.Client
{
    public class AddClientCommand:IRequest<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public string CPF { get; set; }


        public static implicit operator Core.Client (AddClientCommand command)
        {
            return new Core.Client()
            {
                CPF = command.CPF,
                Email = command.Email,
                Name = command.Name,
                Salary = command.Salary
            };
        }
    }
}

