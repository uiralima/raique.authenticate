using Raique.Authenticate.Common.Models;
using Raique.Microservices.Authenticate.Protocols;
using Raique.Microservices.Authenticate.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AspNet.API.Controllers
{
    public class CreateAppController : ApiController
    {
        private readonly IAppRepository _appRepository;

        public CreateAppController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        
        [HttpPost]
        public async Task<string> Post([FromBody] App app)
        {
            return await CreateApp.Execute(_appRepository, app.Name);
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await Task.Run(() => "Teste");
        }
    }
}
