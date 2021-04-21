using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using Raique.Commom.Controller;
using Raique.Microservices.Authenticate.Protocols;
using Raique.Microservices.Authenticate.UseCases;
using System.Threading.Tasks;

namespace Raique.Authenticate.Common.Controllers
{
    public class CreateAppControllerImpl : BaseController, ICreateAppControler
    {
        private readonly IAppRepository _appRepository;

        public CreateAppControllerImpl(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public async Task<string> Post(App app)
        {
            return await CreateApp.Execute(_appRepository, app.Name);
        }

        public override bool AppRequired => false;
        public override bool UserRequired => false;
    }
}
