using Raique.Common.Controller;
using Raique.Microservices.Authenticate.Domain;
using System.Threading.Tasks;

namespace Raique.Authenticate.Common.Contracts
{
    public interface ITokenController : IController
    {
        Task<User> Validate();
    }
}
