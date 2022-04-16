using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanDsi.Core.Models;

namespace VanDsi.Core.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        void AddUser(User user);
        void UpdateUser(User user);
        User GetUserById(int id);
        User GetUserByUserNameAndPassword(string userName, string password);
        void SaveRefreshToken(int id, string refreshToken);
        User GetUserWithRefreshTokenByRefreshToken(string refreshToken);
        void RemoveRefreshToken(User user);
    }
}
