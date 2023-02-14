using System;
using MediatR;

namespace Financial.Services.Application.Commands
{
    public class AddAccountCommand:IRequest<string>
    {
        public AddAccountCommand()
        {
            UserId = Guid.NewGuid();
            
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; } = default;
        public bool IsActive { get; set; } = true;
    }
}

