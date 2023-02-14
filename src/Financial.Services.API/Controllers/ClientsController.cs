using Financial.Services.Application.InputModels;
using Financial.Services.OpenBank.Core.Domain;
using Financial.Services.OpenBank.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Services.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientsController:Controller
    {
        private readonly IRepository<Client> _repository;

        public ClientsController(IRepository<Client> repository)
        {
            _repository = repository;
        }

        [HttpGet("cpf")]
        public async Task<IActionResult> GetByCPF(string cpf)
        {
            return Ok(await _repository.GetByCPF(cpf));
        }

        [HttpGet]
        public async Task <IActionResult> GetClients()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientInputModel client)
        {
           var response =  _repository.AddNew(client.ToEntity());

            return Ok($"New client Added:{client.Name} ");
        }

        [HttpPut]
        public async Task<IActionResult> Put(ClientInputModel client)
        {
            var response = _repository.Edit(client.ToEntity());

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)

        {
            var response = _repository.Delete(id);
            return Ok();
        }


    }
}

