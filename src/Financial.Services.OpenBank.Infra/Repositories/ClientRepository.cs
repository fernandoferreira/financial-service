using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Services.OpenBank.Core.Domain;

namespace Financial.Services.OpenBank.Infra.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private static Dictionary<Guid, Client> _clients = new Dictionary<Guid, Client>();

        public async Task AddNew(Client item)
        {
            await Task.Run(() => _clients.Add(item.Id, item));
        }

        public async Task Delete(Guid id)
        {
            await Task.Run(() => _clients.Remove(id));
        }

        public async Task Edit(Client item)
        {
            await Task.Run(() =>
            {
                var clientToEdit = _clients.Where(c => c.Value.CPF == item.CPF)
                .FirstOrDefault();
                var result = _clients.Remove(clientToEdit.Key);
                _clients.Add(item.Id, item);
            });
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await Task.Run(() => _clients.Values.ToList());
        }

        public async Task<Client> GetByCPF(string cpf)
        {
            return await Task.Run(() => _clients.Values.Where(c => c.CPF == cpf).SingleOrDefault());
        }

        public async Task<Client> GetById(Guid Id)
        {
            return await Task.Run(() => _clients.GetValueOrDefault(Id));
        }
    }
}

