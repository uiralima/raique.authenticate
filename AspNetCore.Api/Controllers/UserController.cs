using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using Raique.Microservices.Authenticate.Protocols;
using System.Threading.Tasks;

namespace AspNetCore.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly IUserController _controller;
        public UserController(IUserController controller,
            ITokenRepository tokenRepository,
            IUserRepository userRepository) : base(controller, tokenRepository, userRepository)
        {
            _controller = controller;
        }

        [ActionName("Create")]
        [HttpPost]
        public async Task<int> Create([FromBody]NewUser userData)
        {
            return await _controller.Create(userData);
        }
    }
}
