using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using Raique.Microservices.Authenticate.Protocols;
using System.Threading.Tasks;
using System.Web.Http;

namespace AspNet.API.Controllers
{
    public class UserController : MainController
    {
        private readonly IUserController _controller;
        public UserController(IUserController controller, ITokenRepository tokenRepository, IUserRepository userRepository) : base(controller, tokenRepository, userRepository)
        {
            _controller = controller;
        }

        [Route("api/User/Create")]
        [HttpPost]
        public async Task<int> Create([FromBody] NewUser userData)
        {
            return await _controller.Create(userData);
        }

        [Route("api/User/CreatePasswordRecovery")]
        [HttpPost]
        public async Task<string> CreatePasswordRecovery([FromBody]CreatePasswordRecovery data)
        {
            return await _controller.PasswordRecovery(data.UserName);
        }
        [Route("api/User/ChangePasswordWithCode")]
        [HttpPost]
        public async Task<bool> ChangePasswordWithCode([FromBody] ChangePasswordWithCode data)
        {
            return await _controller.ChangePasswordWithACode(data.UserName, data.Code, data.Password);
        }

    }
}
