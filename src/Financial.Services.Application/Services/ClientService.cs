using Financial.Services.Application.InputModels;
using Financial.Services.OpenBank.Core.Domain;
using Financial.Services.OpenBank.Infra.Cache;
using Financial.Services.OpenBank.Infra.Repositories;

namespace Financial.Services.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _repository;
        private readonly ICustomMemoryCache _customCache;
        private const string CACHE_KEY = "clients";

        public ClientService(IRepository<Client> repository, ICustomMemoryCache customCache)
        {
            _repository = repository;
            _customCache = customCache;
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
            var clients = _customCache.ReadFromCache(CACHE_KEY);

            if (clients != null)
                return (IEnumerable<Client>)clients;

            clients = await _repository.GetAll();
            _customCache.SetCache(CACHE_KEY, clients);

            return (IEnumerable<Client>)clients;
        }

        public async Task<Client> GetClientByCPF(string cpf)
        {
            return await _repository.GetByCPF(cpf);
        }
    }
}

