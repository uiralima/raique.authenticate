using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using Raique.Common.Controller;
using Raique.Microservices.Authenticate.Protocols;
using Raique.Microservices.Authenticate.UseCases;
using System.Threading.Tasks;

namespace Raique.Authenticate.Common.Controllers
{
    public class AppControllerImpl : BaseController, IAppControler
    {
        private readonly IAppRepository _appRepository;

        public AppControllerImpl(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public async Task<string> Create(App app)
        {
            return await CreateApp.Execute(_appRepository, app.Name);
        }

        public override bool AppRequired => false;
        public override bool UserRequired => false;
    }
}
