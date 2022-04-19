using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;

namespace VanDsi.Core.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User GetUserById(int id);
        User GetUserByUserNameAndPassword(string userName, string password);
        void SaveRefreshToken(int id, string refreshToken);
        User GetUserWithRefreshTokenByRefreshToken(string refreshToken);
        void RemoveRefreshToken(User user);
        bool AnyUser(string userName, string password);
    }
}
