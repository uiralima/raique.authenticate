using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using Raique.Microservices.Authenticate.Protocols;
using System.Threading.Tasks;
using System.Web.Http;

namespace AspNet.API.Controllers
{
    public class AppController : MainController
    {
        private readonly IAppControler _controller;

        [Route("api/App/path/{teste}/{p2}")]
        [HttpGet]
        public string Getdfsgrgerger(string teste, int p2)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            for(int i=0; i<p2; i++)
            {
                result.Append(teste);
            }
            return result.ToString();
        }

        public AppController(IAppControler controller, ITokenRepository tokenRepository, IUserRepository userRepository) : base(controller, tokenRepository, userRepository)
        {
            _controller = controller;
        }

        [Route("api/App/Create")]
        [HttpPost]
        public async Task<string> Create([FromBody] App app)
        {
            return await _controller.Create(app);
        }
    }
}
