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
        private readonly IPasswordRecoveryRepository _passwordRecoveryRepository;
        private readonly ICodeCreator _codeCreator;

        public UserControllerImpl(IAppRepository appRepository, IUserRepository userRepository, IPasswordRecoveryRepository passwordRecoveryRepository, ICodeCreator codeCreator)
        {
            _appRepository = appRepository;
            _userRepository = userRepository;
            _passwordRecoveryRepository = passwordRecoveryRepository;
            _codeCreator = codeCreator;
        }
        public async Task<int> Create(NewUser userData)
        {
            return await CreateUser.Execute(_appRepository, _userRepository, AppKey, userData.UserName, userData.Password);
        }
        public async Task<bool> ChangePasswordWithACode(string userName, string code, string password)
        {
            return await Raique.Microservices.Authenticate.UseCases.ChangePasswordWithCode.Execute(_userRepository, userName, code, password, AppKey);
        }
        public async Task<string> PasswordRecovery(string userName)
        {
            return await Raique.Microservices.Authenticate.UseCases.CreatePasswordRecovery.Execute(_passwordRecoveryRepository, _userRepository, _codeCreator, userName, AppKey);
        }
        public override bool UserRequired => false;

    }
}
