
using Raique.Common.Controller;

namespace AspNet.API.Controllers
{
    public abstract class MainController : Raique.Common.HTTP.AspNet.Controller.Base
    {
        protected MainController(IController controller) : base(controller)
        {
        }

        public override bool AppRequired => LogicalController.AppRequired;
        public override bool DeviceRequired => LogicalController.DeviceRequired;
        public override bool UserRequired => LogicalController.UserRequired;
    }
}