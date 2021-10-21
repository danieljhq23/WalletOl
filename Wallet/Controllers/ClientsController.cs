using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities;
using Wallet.Interfaces;
using Wallet.Repositories;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ICoreRepository<Client> _clientBusiness;        
        public ClientsController(CoreClientRepository repository)
        {
            _clientBusiness = repository;           
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<Client>> Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _clientBusiness.Add(client);
            return CreatedAtAction("Get", client);

        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            return await _clientBusiness.GetAll();
        }

        // GET: api/[controller]/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var client = await _clientBusiness.Get(id); 
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }

        // PUT: api/[controller]/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }
            await _clientBusiness.Update(client);
            return NoContent();
        }

        // DELETE: api/[controller]/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            var clientExist = await _clientBusiness.Get(id);

            if (clientExist == null)
            {
                return NotFound();
            }            

            var client = await _clientBusiness.Delete(id);            

            return client;
        }

    }

}
