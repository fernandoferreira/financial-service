using Financial.Services.Application.InputModels;
using Financial.Services.OpenBank.Core.Domain;
using Financial.Services.OpenBank.Infra.Repositories;

namespace Financial.Services.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _repository;

        public ClientService(IRepository<Client> repository)
        {
            _repository = repository;
        }

        public async Task AddNew(ClientInputModel model)
        {
            await _repository.AddNew(model.ToEntity());
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task Edit(ClientInputModel model)
        {
            await _repository.Edit(model.ToEntity());
        }

        public async Task<IEnumerable<Client>> GetAllclients()
        {
            return await _repository.GetAll();
        }

        public async Task<Client> GetClientByCPF(string cpf)
        {
            return await _repository.GetByCPF(cpf);
        }
    }
}

