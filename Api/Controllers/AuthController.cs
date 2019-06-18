using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using BusinessLogic.Commands;
using BusinessLogic.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Encryption _enc;
        private readonly ILogInUserCommand _logInUser;

        public AuthController(Encryption enc, ILogInUserCommand loginUser)
        {
            _enc = enc;
            _logInUser = loginUser;
        }


        // POST: api/Auth
        [HttpPost]
        public IActionResult Post([FromBody] LogUser dto)
        {
            var user = _logInUser.Execute(dto);

            var stringObjekat = JsonConvert.SerializeObject(user);

            var encryptedString = _enc.EncryptString(stringObjekat);

            return Ok(new { token = encryptedString });
        }

        [HttpGet("decode")]
        public IActionResult Decode(string value)
        {
            var decryptedString = _enc.DecryptString(value);

            decryptedString = decryptedString.Replace("\f", "");

            var userObjekat = JsonConvert.DeserializeObject<LoggedUser>(decryptedString);

            return null;
        }
    }
}
