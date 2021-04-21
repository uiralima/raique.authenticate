using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using Raique.Common.Controller;
using Raique.Microservices.Authenticate.Protocols;
using Raique.Microservices.Authenticate.UseCases;
using System.Threading.Tasks;

namespace Raique.Authenticate.Common.Controllers
{
    public class CreateUserControllerImpl : BaseController, ICreateUserController
    {
        private readonly IAppRepository _appRepository;
        private readonly IUserRepository _userRepository;

        public CreateUserControllerImpl(IAppRepository appRepository, IUserRepository userRepository)
        {
            _appRepository = appRepository;
            _userRepository = userRepository;
        }
        public async Task<int> Post(NewUser userData)
        {
            return await CreateUser.Execute(_appRepository, _userRepository, AppKey, userData.UserName, userData.Password);
        }
        public override bool UserRequired => false;

    }
}
