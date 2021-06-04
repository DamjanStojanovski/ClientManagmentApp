using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using ClientManager.DemoApp.Domain.Models;
using ClientManager.DemoApp.Domain.Repositories.Interfaces;

namespace ClientsManager.RestfulWebAPI.Controllers
{
    //[Route("api/clients")]
    public class ClientsController : ApiController
    {
        private readonly IClientRepository _clientRepository;
        public ClientsController(IClientRepository clientsRepository)
        {
            _clientRepository = clientsRepository;
        }

        // GET: api/Clients
        [HttpGet]
        [ResponseType(typeof(List<Client>))]
        public IHttpActionResult GetClients()
        {
            var clients = _clientRepository.GetAllClients();
            return Ok(clients);
        }

        // GET: api/Clients/5
        [HttpGet]
        //[Route("api/clients/id")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = _clientRepository.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
    }
}