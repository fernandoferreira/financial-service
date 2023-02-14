using System;
using Financial.Services.Application.Commands;
using Financial.Services.OpenBank.Core.Domain;
using Financial.Services.OpenBank.Infra.Repositories;
using MediatR;

namespace Financial.Services.Application.Handlers
{
    public class DeleteAccountCommandHandler:IRequestHandler<DeleteAccountCommand,string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Account> _repository;

        public DeleteAccountCommandHandler(IMediator mediator, IRepository<Account> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);
                await _mediator.Publish(new { Id = request.Id });
                return await Task.FromResult("Account successfuly deleted!");

            }
            catch (Exception ex)
            {
                await _mediator.Publish(new { Message = ex.Message, StackError = ex.InnerException });
                return await Task.FromResult($"The following exception ocurred: {ex.HResult}");

            }
        }
    }
}

