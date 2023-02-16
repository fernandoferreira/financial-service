using Financial.Services.Application.InputModels;
using Financial.Services.OpenBank.Core.Domain;

namespace Financial.Services.Application.Services
{
    public interface IClientService
    {
        Task<Client> GetClientByCPF(string cpf);

        Task<IEnumerable<Client>> GetAllclients();

        Task AddNew(ClientInputModel model);

        Task Edit(ClientInputModel model);

        Task Delete(Guid id);

    }
}

