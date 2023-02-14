using System;
using MediatR;

namespace Financial.Services.Application.Commands.Client
{
    public class EditClientCommand:IRequest<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public string CPF { get; set; }
    }
}

