using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDsi.Core.DTOs
{
    public class UserDto: BaseDto
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string NameLastName { get; set; }
    }
}
