using System;
using Financial.Services.OpenBank.Core.Domain;
using MediatR;

namespace Financial.Services.Application.Commands
{
    public class EditAccountCommand:IRequest<string>
    {
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }

    }
}

