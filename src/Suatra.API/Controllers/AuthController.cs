using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suatra.Application.Features.Auth.Commands.ActivateAccount;
using Suatra.Application.Features.Auth.Commands.CreateAccount;
using Suatra.Application.Features.Auth.Dto.Requests;

namespace Suatra.API.Controllers
{
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController: BaseController
    {
        [HttpPost("account")]
        public async Task<ActionResult> CreateAccount(CreateAccountRequest request)
        {
             await Mediator.Send(new CreateAccountCommand(request));
             return Ok();
        }

        [HttpPost("activate")]
        public async Task<ActionResult> ActivateAccount(ActivateAccountRequest request)
        {
            await Mediator.Send(new ActivateAccountCommand(request));
            return Ok();
        }
    }
}