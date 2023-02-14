using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financial.Services.OpenBank.Infra.Repositories
{
    public interface IRepository<T>
    {
        Task AddNew(T item);
        Task Edit(T item);
        Task Delete(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByCPF(string cpf);
        Task<T> GetById(Guid Id);
    }
}

