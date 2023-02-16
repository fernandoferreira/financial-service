using Financial.Services.Application.InputModels;
using Financial.Services.Application.Services;
using Financial.Services.OpenBank.Core.Domain;
using Financial.Services.OpenBank.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Services.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("cpf")]
        public async Task<IActionResult> GetByCPF(string cpf)
        {
            return Ok(await _service.GetClientByCPF(cpf));
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            return Ok(await _service.GetAllclients());
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientInputModel client)
        {
            var response = _service.AddNew(client);

            return Ok($"New client Added:{client.Name} ");
        }

        [HttpPut]
        public async Task<IActionResult> Put(ClientInputModel client)
        {
            var response = _service.Edit(client);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)

        {
            var response = _service.Delete(id);
            return Ok();
        }


    }
}

