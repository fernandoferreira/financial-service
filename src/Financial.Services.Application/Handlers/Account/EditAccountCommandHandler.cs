using System;
using Financial.Services.Application.Commands;
using Financial.Services.OpenBank.Core.Domain;
using Financial.Services.OpenBank.Infra.Repositories;
using MediatR;

namespace Financial.Services.Application.Handlers
{
    public class EditAccountCommandHandler:IRequestHandler<EditAccountCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Account> _repository;

        public EditAccountCommandHandler(IMediator mediator, IRepository<Account> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(EditAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account() { Amount = request.Amount, IsActive = request.IsActive };

            try
            {
                await _repository.Edit(account);
                await _mediator.Publish(new { Amount = request.Amount, IsActive = request.IsActive });
                return await Task.FromResult($"The account was updated!");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new { Message = ex.Message, StackError = ex.InnerException });
                return await Task.FromResult($"The following exception ocurred: {ex.HResult}");
            }
        }
    }
}

