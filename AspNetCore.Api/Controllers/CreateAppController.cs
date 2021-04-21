using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using Raique.Common.HTTP.AspNetCore.Controller;
using Raique.Microservices.Authenticate.Protocols;
using System.Threading.Tasks;

namespace AspNetCore.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CreateAppController : MainController
    {
        private readonly ICreateAppControler _controller;

        public CreateAppController(ICreateAppControler controller,
            ITokenRepository tokenRepository, IUserRepository userRepository) : base(controller, tokenRepository, userRepository)
        {
            _controller = controller;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] App app)
        {
            return await _controller.Post(app);
        }
    }
}
