using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;

namespace VanDsi.Core.Services
{
    public interface IUserService: IService<User>
    {
        CustomResponseDto<UserDto> GetUserById(int id);
        CustomResponseDto<UserDto> GetUserByUserNameAndPassword(string userName, string password);
        void SaveRefreshToken(int id, string refreshToken);
        CustomResponseDto<UserDto> GetUserWithRefreshTokenByRefreshToken(string refreshToken);
        void RemoveRefreshToken(UserDto userDto);
    }
}
