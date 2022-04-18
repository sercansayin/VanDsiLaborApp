using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanDsi.Core.Services;

namespace VanDsi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }




    }
}
