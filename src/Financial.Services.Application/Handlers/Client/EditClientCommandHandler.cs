using System;
using Financial.Services.Application.Commands.Client;
using Financial.Services.OpenBank.Core.Domain;
using Financial.Services.OpenBank.Infra.Repositories;
using MediatR;

namespace Financial.Services.Application
{
    public class EditClientcommandHandler:IRequestHandler<EditClientCommand,string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Client> _repository;

        public EditClientcommandHandler(IMediator mediator, IRepository<Client> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(EditClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client() { Name = request.Name, Email = request.Email, CPF = request.CPF, Salary = request.Salary };

            try
            {
                await _repository.Edit(client);
                await _mediator.Publish(new { Name = request.Name, Email = request.Email, CPF = request.CPF, Salary = request.Salary });
                return await Task.FromResult($"The clint was updated!");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new { Message = ex.Message, StackError = ex.InnerException });
                return await Task.FromResult($"The following exception ocurred: {ex.HResult}");
            }
        }
    }
}

