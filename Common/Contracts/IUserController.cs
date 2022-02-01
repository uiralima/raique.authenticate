using Raique.Authenticate.Common.Models;
using Raique.Common.Controller;
using System.Threading.Tasks;

namespace Raique.Authenticate.Common.Contracts
{
    public interface IUserController : IController
    {
        Task<int> Create(NewUser userData);
        Task<bool> ChangePasswordWithACode(string userName, string code, string password);
        Task<string> PasswordRecovery(string userName);
    }
}
