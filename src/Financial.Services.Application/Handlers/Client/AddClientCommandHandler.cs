using System;
using Financial.Services.Application.Commands.Client;
using Financial.Services.OpenBank.Core.Domain;
using Financial.Services.OpenBank.Infra.Repositories;
using MediatR;

namespace Financial.Services.Application
{
    public class AddClientCommandHandler:IRequestHandler<AddClientCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Client> _repository;

        public AddClientCommandHandler(IMediator mediator, IRepository<Client> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client() { CPF = request.CPF, Email = request.Email, Name = request.Name, Salary = request.Salary };

            try
            {
                await _repository.AddNew(client);
                await _mediator.Publish(new { Name = request.Name, CPF = request.CPF, Email = request.Email });
                return await Task.FromResult($"Client {request.Name} successfuly added!");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new { Name = request.Name, CPF = request.CPF, Email = request.Email });
                return await Task.FromResult($"The following exception ocurred: {ex.HResult}");
            }
        }

    }
}

