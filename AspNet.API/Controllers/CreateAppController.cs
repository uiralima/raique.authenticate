using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace AspNet.API.Controllers
{
    public class CreateAppController : MainController
    {
        private readonly ICreateAppControler _controller;

        public CreateAppController(ICreateAppControler controller) : base(controller)
        {
            _controller = controller;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] App app)
        {
            return await _controller.Post(app);
        }
    }
}
