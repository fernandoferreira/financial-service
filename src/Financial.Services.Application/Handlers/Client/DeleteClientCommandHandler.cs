using System;
using Financial.Services.Application.Commands.Client;
using Financial.Services.OpenBank.Core.Domain;
using Financial.Services.OpenBank.Infra.Repositories;
using MediatR;

namespace Financial.Services.Application
{
    public class DeleteClientCommandHandler:IRequestHandler<DeleteClientCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Client> _repository;

        public DeleteClientCommandHandler(IMediator mediator, IRepository<Client> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);
                await _mediator.Publish(new { ID = request.Id });
                return await Task.FromResult($"Client successfuly deleted.");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new { Message = ex.Message, StackError = ex.InnerException });
                return await Task.FromResult($"The following exception ocurred: {ex.HResult}");
            }
        }
    }
}

