using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Models;
using Wallet.Services;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {


        }

        // POST: api/[controller]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] LoginModel model)
        {
            var user = UserService.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "User or password invalid" });

            var token = TokenService.CreateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }

        // GET: api/[controller]/AuthorizeAnalista
        //Usar token generado en controller Authenticate
        [HttpGet("AuthorizeAnalista")]
        [Authorize(Roles = "Analista")]
        public string AuthorizeAnalista()
        {
            return "Analista Autorizado";
        }
    }
}
