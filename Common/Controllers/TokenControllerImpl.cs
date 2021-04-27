using Raique.Authenticate.Common.Contracts;
using Raique.Common.Controller;
using Raique.Microservices.Authenticate.Domain;
using System.Threading.Tasks;
using Raique.Microservices.Authenticate.UseCases;
using Raique.Microservices.Authenticate.Protocols;

namespace Raique.Authenticate.Common.Controllers
{
    public class TokenControllerImpl : BaseController, ITokenController
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenInfoExtractor _tokenInfoExtractor;

        public TokenControllerImpl(ITokenRepository tokenRepository, IUserRepository userRepository, ITokenInfoExtractor tokenInfoExtractor)
        {
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _tokenInfoExtractor = tokenInfoExtractor;
        }
        public async Task<User> Validate()
        {
            return await GetTokenInfo.Execute(_tokenRepository, _userRepository, _tokenInfoExtractor, Token, AppKey, Device);
        }
    }
}
