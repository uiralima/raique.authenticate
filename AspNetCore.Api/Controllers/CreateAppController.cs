using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raique.Authenticate.Common.Models;
using Raique.Microservices.Authenticate.Protocols;
using Raique.Microservices.Authenticate.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CreateAppController : ControllerBase
    {
        private readonly IAppRepository _appRepository;

        public CreateAppController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpPost]
        public async Task<string> Post([FromBody]App app)
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
