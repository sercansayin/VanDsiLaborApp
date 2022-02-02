using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDsi.Core
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string NameLastName { get; set; }
        public bool IsDelete { get; set; }
        public string RefleshToken { get; set; }
        public DateTime? RefleshTokenAndDate { get; set; }
    }
}
