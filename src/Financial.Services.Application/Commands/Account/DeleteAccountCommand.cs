using System;
using MediatR;

namespace Financial.Services.Application.Commands
{
    public class DeleteAccountCommand:IRequest<string>
    {
        public int Id { get; set; }
    }
}

