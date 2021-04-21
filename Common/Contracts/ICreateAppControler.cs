using Raique.Authenticate.Common.Models;
using Raique.Commom.Controller;
using System.Threading.Tasks;

namespace Raique.Authenticate.Common.Contracts
{
    public interface ICreateAppControler : IController
    {
        Task<string> Post(App app);
    }
}
