using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;

namespace VanDsi.Core.Services
{
    public interface ILaborService: IService<Labor>
    {
        Task<CustomResponseDto<List<LaborDto>>> GetLaborsForEmployeeId(int employeId);
    }
}
