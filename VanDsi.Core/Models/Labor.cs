using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDsi.Core
{
    public class Labor:BaseEntity
    {
        public int PersonnelId { get; set; }
        public int UserId { get; set; }
        public short Year { get; set; }
        public byte Month { get; set; }
        public byte Days { get; set; }
        public decimal Winnings { get; set; }
        public string WorkPlaceNumber { get; set; }
        public Personnel Personnel { get; set; }
        public User User { get; set; }
    }
}
