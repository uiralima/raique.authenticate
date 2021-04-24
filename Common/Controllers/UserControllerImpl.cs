using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using Raique.Common.Controller;
using Raique.Microservices.Authenticate.Protocols;
using Raique.Microservices.Authenticate.UseCases;
using System.Threading.Tasks;

namespace Raique.Authenticate.Common.Controllers
{
    public class UserControllerImpl : BaseController, IUserController
    {
        private readonly IAppRepository _appRepository;
        private readonly IUserRepository _userRepository;

        public UserControllerImpl(IAppRepository appRepository, IUserRepository userRepository)
        {
            _appRepository = appRepository;
            _userRepository = userRepository;
        }
        public async Task<int> Create(NewUser userData)
        {
            return await CreateUser.Execute(_appRepository, _userRepository, AppKey, userData.UserName, userData.Password);
        }
        public override bool UserRequired => false;

    }
}
