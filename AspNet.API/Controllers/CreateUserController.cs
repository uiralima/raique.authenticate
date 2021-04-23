using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using Raique.Microservices.Authenticate.Protocols;
using System.Threading.Tasks;
using System.Web.Http;

namespace AspNet.API.Controllers
{
    public class CreateUserController : MainController
    {
        private readonly ICreateUserController _controller;
        public CreateUserController(ICreateUserController controller, ITokenRepository tokenRepository, IUserRepository userRepository) : base(controller, tokenRepository, userRepository)
        {
            _controller = controller;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] NewUser userData)
        {
            return await _controller.Post(userData);
        }
    }
}
