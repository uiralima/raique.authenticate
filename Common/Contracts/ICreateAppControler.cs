using Raique.Authenticate.Common.Models;
using System.Threading.Tasks;

namespace Raique.Authenticate.Common.Contracts
{
    public interface ICreateAppControler
    {
        Task<string> Post(App app);
    }
}
