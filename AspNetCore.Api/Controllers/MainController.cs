﻿using Raique.Commom.Controller;
using Raique.Common.HTTP.AspNetCore.Controller;
using Raique.Microservices.Authenticate.Protocols;

namespace AspNetCore.Api.Controllers
{
    public abstract class MainController : Base
    {
        private readonly IController _controller;

        protected MainController(IController controller, ITokenRepository tokenRepository, IUserRepository userRepository) : base(tokenRepository, userRepository)
        {
            _controller = controller;
        }

        public override bool AppRequired => _controller.AppRequired;
        public override bool DeviceRequired => _controller.DeviceRequired;
        public override bool UserRequired => _controller.UserRequired;
    }
}
