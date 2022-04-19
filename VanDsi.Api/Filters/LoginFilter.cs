using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VanDsi.Core.DTOs;
using VanDsi.Core.Services;
using VanDsi.Core.Security;

namespace VanDsi.Api.Filters
{
    public class LoginFilter<T> : IAsyncActionFilter where T : LoginDto
    {
        private readonly IUserService _userService;

        public LoginFilter(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var login = context.ActionArguments.Values.FirstOrDefault();
            if (login is LoginDto loginDto)
            {
                var haveLogin = _userService.AnyUser(loginDto);
                if (!haveLogin)
                {
                    context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(400, $"{typeof(T).Name}({loginDto.UserName}) user not Found or Password is wrong"));
                }
                else
                {
                    await next.Invoke();
                    return;
                }
            }
            else
            {
                await next.Invoke();
                return;
            }
        }
    }
}
