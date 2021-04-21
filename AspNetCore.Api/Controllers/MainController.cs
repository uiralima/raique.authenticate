using Raique.Common.Controller;
using Raique.Common.HTTP.AspNetCore.Controller;
using Raique.Microservices.Authenticate.Protocols;

namespace AspNetCore.Api.Controllers
{
    public abstract class MainController : Base
    {
        protected MainController(IController controller, ITokenRepository tokenRepository, IUserRepository userRepository) : base(tokenRepository, userRepository, controller)
        { }

        public override bool AppRequired => LogicalController.AppRequired;
        public override bool DeviceRequired => LogicalController.DeviceRequired;
        public override bool UserRequired => LogicalController.UserRequired;
    }
}
