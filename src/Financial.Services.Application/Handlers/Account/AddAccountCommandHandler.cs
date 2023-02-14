using System;
using MediatR;
using Financial.Services.Application.Commands;
using Financial.Services.OpenBank.Core.Domain;
using Financial.Services.OpenBank.Infra.Repositories;

namespace Financial.Services.Application.Handlers
{
    public class AddAccountCommandHandler:IRequestHandler<AddAccountCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Account> _repository;

        public AddAccountCommandHandler(IMediator mediator, IRepository<Account> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account() { Id = request.Id, UserId = request.UserId};

            try
            {
               await _repository.AddNew(account);
               await _mediator.Publish(new { Id = account.Id });
                return await Task.FromResult($"Account number {account.Id} created!");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new { Message = ex.Message, StackError = ex.StackTrace });
                return await Task.FromResult($"The following exception occured: {ex.HResult}");
            }
        }
    }
}

