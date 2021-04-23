
using Raique.Common.Controller;
using Raique.Microservices.Authenticate.Protocols;

namespace AspNet.API.Controllers
{
    public abstract class MainController : Raique.Common.HTTP.AspNet.Controller.Base
    {
        protected MainController(IController controller, ITokenRepository tokenRepository, IUserRepository userRepository) : base(tokenRepository, userRepository, controller)
        {
        }

        public override bool AppRequired => LogicalController.AppRequired;
        public override bool DeviceRequired => LogicalController.DeviceRequired;
        public override bool UserRequired => LogicalController.UserRequired;
    }
}