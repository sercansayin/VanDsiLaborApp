using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using VanDsi.Core.Models;
using VanDsi.Core.Models.Security;
using VanDsi.Core.Repositories;

namespace VanDsi.Repository.Repositories
{
    public class UserRepository:GenericRepository<User>, IUserRepository
    {
        private readonly TokenOptions _tokenOptions;
        public UserRepository(AppDbContext context, IOptions<TokenOptions> tokenOptions) : base(context)
        {
            _tokenOptions = tokenOptions.Value;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName && u.UserPassword == password);
        }

        public void SaveRefreshToken(int id, string refreshToken)
        {
            var newUser = _context.Users.Find(id);
            newUser.RefreshToken = refreshToken;
            newUser.RefreshTokenAndDate = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenExpiration);
        }

        public User GetUserWithRefreshTokenByRefreshToken(string refreshToken)
        {
            return _context.Users.FirstOrDefault(rt =>rt.RefreshToken == refreshToken);
        }

        public void RemoveRefreshToken(User user)
        {
            var newUser = _context.Users.Find(user.Id);
            newUser.RefreshToken = null;
        }
    }
}
