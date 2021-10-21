using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities;
using Wallet.Interfaces;
using Wallet.Models;
using Wallet.Repositories;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ICoreRepository<Account> _accountBusiness;
        private readonly ICoreRepository<Client> _clientBusiness;
        private readonly IAccountService _accountService;

        public AccountController(CoreAccountRepository accountRepository, 
            CoreClientRepository clientRepository, 
            IAccountService accountService)
        {
            _accountBusiness = accountRepository;
            _clientBusiness = clientRepository;
            _accountService = accountService;

        }

        // GET: api/[controller]/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> Get(int id)
        {
            var account = await _accountBusiness.Get(id);
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        // GET: api/[controller]/GetBalance/1
        [HttpGet("GetBalance/{ClientId}")]
        public async Task<ActionResult<OutputBalance>> GetBalance(int ClientId)
        {
            var result = await _accountService.GetBalanceClient(ClientId);

            return result;
        }

        // POST: api/[controller]/AddAccount
        [HttpPost("AddAccount")]       
        public async Task<ActionResult<Account>> AddAccount([FromBody] CreateAccountModel input)
        {
            var client = await _clientBusiness.Get(input.ClientId);
            if (client == null)
            {
                return BadRequest(new { message = "Cliente no existe" });
            }

            var account = await _accountService.SaveAccountAsync(input);

            if (account == null)
            {
                return BadRequest();
            }

            return account;
        }

        // PUT: api/[controller]/2
        [HttpPut("AddCredit/{Accountid}")]
        public async Task<IActionResult> AddCredit(int Accountid, UpdateAccountModel input)
        {
            if (Accountid != input.Id)
            {
                return BadRequest();
            }

            var client = await _accountBusiness.Get(input.Id);
            if (client.ClientID != input.ClientId)
            {
                return BadRequest(new { message = "La cuenta no pertenece al cliente:" + input.ClientId.ToString() });
            }

            if (input.Amount <= 0)
            {
                return BadRequest(new { message = "Monto no válido" });
            }

            await _accountService.AddCredit(input);

            return NoContent();
        }      


    }
}
