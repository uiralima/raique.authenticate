using Raique.Authenticate.Common.Contracts;
using Raique.Common.Controller;
using System.Threading.Tasks;
using Raique.Microservices.Authenticate.Protocols;
using Raique.Authenticate.Common.Models;

namespace Raique.Authenticate.Common.Controllers
{
    public class LoginControllerImpl : BaseController, ILoginController
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenCreator _tokenCreator;

        public LoginControllerImpl(ITokenRepository tokenRepository, IUserRepository userRepository, ITokenCreator tokenCreator)
        {
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _tokenCreator = tokenCreator;
        }
        public async Task<string> Login(LoginInfo login)
        {
            return await Microservices.Authenticate.UseCases.Login.Execute(_tokenRepository, _userRepository,
                _tokenCreator, AppKey, login.UserName, login.Password, Device);
        }

        public async Task Logoff()
        {
            await Microservices.Authenticate.UseCases.Logoff.Execute(_tokenRepository, Token, Device);
        }

        public override bool UserRequired => false;
    }
}
