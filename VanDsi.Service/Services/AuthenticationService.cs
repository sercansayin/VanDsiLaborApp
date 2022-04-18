using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;
using VanDsi.Core.Models.Security;
using VanDsi.Core.Security;
using VanDsi.Core.Services;

namespace VanDsi.Service.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;
        private readonly IMapper _mapper;

        public AuthenticationService(IUserService userService, ITokenHandler tokenHandler, IMapper mapper)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
            _mapper = mapper;
        }


        public CustomResponseDto<AccessToken> CreateAccessToken(string userName, string password)
        {
            var userDto = _userService.GetUserByUserNameAndPassword(userName,password);
            if (userDto.StatusCode == 200)
            {
                var user = _mapper.Map<User>(userDto);
                var accessToken = _tokenHandler.createAccessToken(user);
                return CustomResponseDto<AccessToken>.Success(200,accessToken);
            }
            else
            {
                return CustomResponseDto<AccessToken>.Fail(401, "invalid user");
            }
        }

        public CustomResponseDto<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken)
        {
            var userDto = _userService.GetUserWithRefreshTokenByRefreshToken(refreshToken);

            if (userDto.StatusCode == 200)
            {
                if (userDto.Data.RefreshTokenAndDate < DateTime.Now)
                {
                    var user = _mapper.Map<User>(userDto.Data);
                    var accessToken = _tokenHandler.createAccessToken(user);
                    return CustomResponseDto<AccessToken>.Success(200, accessToken);
                }
                else
                {
                    return  CustomResponseDto<AccessToken>.Fail(401, "refresh token expired");
                }
            }
            else
            {
                return CustomResponseDto<AccessToken>.Fail(401, "invalid user");
            }
        }

        public CustomResponseDto<NoContentDto> RevokeRefreshToken(string refreshToken)
        {
            var userDto = _userService.GetUserWithRefreshTokenByRefreshToken(refreshToken);

            if (userDto.StatusCode == 200)
            {
                _userService.RemoveRefreshToken(userDto.Data);
                return CustomResponseDto<NoContentDto>.Success(200);
            }
            else
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "refresh token not found");
            }
        }
    }
}
