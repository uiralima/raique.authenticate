using Microsoft.AspNetCore.Mvc;
using Raique.Authenticate.Common.Contracts;
using Raique.Microservices.Authenticate.Domain;
using Raique.Microservices.Authenticate.Protocols;
using System.Threading.Tasks;

namespace AspNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : MainController
    {
        ITokenController _controller;
        public TokenController(ITokenController controller, ITokenRepository tokenRepository, IUserRepository userRepository)
            : base(controller, tokenRepository, userRepository)
        {
            _controller = controller;
        }
        [HttpGet]
        public async Task<User> Validate()
        {
            return await _controller.Validate();
        }
    }
}
