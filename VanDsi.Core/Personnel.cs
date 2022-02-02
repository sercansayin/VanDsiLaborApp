using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDsi.Core
{
    public class Personnel:BaseEntity
    {
        public string TcNo { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string DateOfEmployment { get; set; }
        public string NameLastName { get; set; }
        public string FirstLastName { get; set; }
        public string FatherName { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public ICollection<Labor> Labors { get; set; }
    }
}
