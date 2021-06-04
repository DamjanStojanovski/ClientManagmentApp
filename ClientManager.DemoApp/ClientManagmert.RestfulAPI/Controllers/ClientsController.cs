using ClientManager.DemoApp.Domain.Enums;
using ClientManager.DemoApp.Domain.Models;
using ClientManager.DemoApp.Domain.Repositories.Interfaces;
using System.Web.Http;

namespace ClientManagmert.RestfulAPI.Controllers
{
    [Route("api/clients")]
    public class ClientsController : ApiController
    {
        private IClientRepository _clientRepository;
        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        // GET api/values
        [HttpGet, Route("api/clients")]
        public IHttpActionResult Get()
        {
            var clients = _clientRepository.GetAllClients();
            return Ok(clients);
        }

        // GET api/values/5
        [HttpGet, Route("api/clients/{id}")]
        public IHttpActionResult GetClientById([FromUri]int id)
        {
            var client = _clientRepository.GetClientById(id);
            if(client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]string firstName, string lastName,int clientType)
        {
            Client newClient = new Client();
            newClient.FirstName = firstName;
            newClient.LastName = lastName;
            newClient.ClientType = (ClientType)clientType;
            var isClientInserted = _clientRepository.InsertClient(newClient);
            if(isClientInserted != 1)
            {
                return BadRequest();
            }
            return Ok(newClient);
        }
    }
}
