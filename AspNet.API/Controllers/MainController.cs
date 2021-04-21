using Raique.Commom.Controller;

namespace AspNet.API.Controllers
{
    public abstract class MainController : Raique.Common.HTTP.AspNet.Controller.Base
    {
        private readonly IController _controller;
        protected MainController(IController controller)
        {
            _controller = controller;
        }

        public override bool AppRequired => _controller.AppRequired;
        public override bool DeviceRequired => _controller.DeviceRequired;
        public override bool UserRequired => _controller.UserRequired;
    }
}