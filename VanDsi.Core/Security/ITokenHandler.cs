using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanDsi.Core.Models;
using VanDsi.Core.Models.Security;

namespace VanDsi.Core.Security
{
    public interface ITokenHandler
    {
        AccessToken createAccessToken(User user);
        void RevokeRefreshToken(User user);
    }
}
