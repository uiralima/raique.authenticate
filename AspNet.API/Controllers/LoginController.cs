using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using Raique.Microservices.Authenticate.Protocols;
using System.Threading.Tasks;
using System.Web.Http;

namespace AspNet.API.Controllers
{
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
    }
}
