using Raique.Authenticate.Common.Models;
using Raique.Common.Controller;
using System.Threading.Tasks;

namespace Raique.Authenticate.Common.Contracts
{
    public interface IUserController : IController
    {
        Task<int> Create(NewUser userData);
    }
}
