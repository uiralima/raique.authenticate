using Microsoft.AspNetCore.Mvc;
using Raique.Common.HTTP.AspNetCore.Controller;
using Raique.Microservices.Authenticate.Protocols;

namespace AspNetCore.Api.Controllers
{
    public abstract class MainController : Base
    {
        protected MainController(ITokenRepository tokenRepository, IUserRepository userRepository) : base(tokenRepository, userRepository)
        {
        }
    }
}
