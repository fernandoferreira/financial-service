using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Services.OpenBank.Core.Domain;

namespace Financial.Services.OpenBank.Infra.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private static Dictionary<Guid, Account> _accounts = new Dictionary<Guid, Account>();

        public AccountRepository() 
        {
        }

        public async Task AddNew(Account item)
        {
            await Task.Run(() => _accounts.Add(item.Id, item));
        }

        public async Task Delete(Guid id)
        {
            await Task.Run(() => _accounts.Remove(id));
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Edit(Account item)
        {
            await Task.Run(() =>
            {
                _accounts.Remove(item.Id);
                _accounts.Add(item.Id, item);
            });
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
           return await Task.Run(() => _accounts.Values.ToList());
        }

        public Task<Account> GetByCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetById(Guid Id)
        {
            return await Task.Run(() => _accounts.GetValueOrDefault(Id));
        }

        public Task<Account> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

