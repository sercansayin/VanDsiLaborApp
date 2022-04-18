using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDsi.Core.DTOs
{
    public class LaborsForEmployeeDto:BaseDto
    {
        public int UserId { get; set; }
        public short Year { get; set; }
        public byte Month { get; set; }
        public byte Days { get; set; }
        public decimal Winnings { get; set; }
        public string WorkPlaceNumber { get; set; }
    }
}
