using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanDsi.Core.Services;

namespace VanDsi.Api.Controllers
{
    public class LaborController : CustomBaseController
    {
        private readonly ILaborService _laborService;

        public LaborController(ILaborService laborService)
        {
            _laborService = laborService;
        }

        [HttpGet("[action]/{employeeId:int}")]
        public async Task<IActionResult> GetLaborsForEmployeeId(int employeeId)
        {
            return CreateActionResult(await _laborService.GetLaborsForEmployeeId(employeeId));
        }
    }
}
