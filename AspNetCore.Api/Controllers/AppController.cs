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
    public class AppController : MainController
    {
        private readonly IAppControler _controller;

        public AppController(IAppControler controller,
            ITokenRepository tokenRepository, IUserRepository userRepository) : base(controller, tokenRepository, userRepository)
        {
            _controller = controller;
        }

        [ActionName("Create")]
        [HttpPost]
        public async Task<string> Create([FromBody] App app)
        {
            return await _controller.Create(app);
        }
    }
}
