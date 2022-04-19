using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanDsi.Api.Filters;
using VanDsi.Core.DTOs;
using VanDsi.Core.Services;

namespace VanDsi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [ServiceFilter(typeof(LoginFilter<LoginDto>))]
        [HttpPost]
        public IActionResult AccessToken(LoginDto loginDto)
        {
            var accessToken = _authenticationService.CreateAccessToken(loginDto.UserName, loginDto.Password);
            return CreateActionResult(accessToken);
        }

        [HttpPost]
        public IActionResult RefreshToken(TokenDto tokenDto)
        {
            var accessToken = _authenticationService.CreateAccessTokenByRefreshToken(tokenDto.RefreshToken);

            return CreateActionResult(accessToken);
        }

        [HttpPost]
        public IActionResult RemoveRefreshToken(TokenDto tokenDto)
        {
           var status = _authenticationService.RemoveRefreshToken(tokenDto.RefreshToken);
           return CreateActionResult(status);
        }
    }
}
