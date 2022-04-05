using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanDsi.Core.Models;

namespace VanDsi.Core.DTOs
{
    public class LaborDto: BaseDto
    {
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public short Year { get; set; }
        public byte Month { get; set; }
        public byte Days { get; set; }
        public decimal Winnings { get; set; }
        public string WorkPlaceNumber { get; set; }
        public Employee Employee { get; set; }
        public User User { get; set; }
    }
}
