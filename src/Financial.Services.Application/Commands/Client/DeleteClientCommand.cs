using System;
using MediatR;

namespace Financial.Services.Application.Commands.Client
{
    public class DeleteClientCommand:IRequest<string>
    {
        public Guid Id { get; set; }
    }
}

