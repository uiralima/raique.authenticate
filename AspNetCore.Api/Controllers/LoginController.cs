using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using Raique.Microservices.Authenticate.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : MainController
    {
        ILoginController _controller;
        public LoginController(ILoginController controller, ITokenRepository tokenRepository, IUserRepository userRepository) 
            : base(controller, tokenRepository, userRepository)
        {
            _controller = controller;
        }

        [HttpPost]
        public async Task<string> Login(LoginInfo login)
        {
            return await _controller.Login(login);
        }

        [HttpDelete]
        public async Task Logoff()
        {
            await _controller.Logoff();
        }
    }
}
