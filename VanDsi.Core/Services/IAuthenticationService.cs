using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models.Security;

namespace VanDsi.Core.Services
{
    public interface IAuthenticationService
    {
        CustomResponseDto<AccessToken> CreateAccessToken(string userName, string password);
        CustomResponseDto<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken);
        CustomResponseDto<NoContentDto> RevokeRefreshToken(string refreshToken);
    }
}
