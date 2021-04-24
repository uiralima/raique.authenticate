using Raique.Authenticate.Common.Models;
using Raique.Common.Controller;
using System.Threading.Tasks;

namespace Raique.Authenticate.Common.Contracts
{
    public interface ILoginController : IController
    {
        Task<string> Login(LoginInfo login);
    }
}
