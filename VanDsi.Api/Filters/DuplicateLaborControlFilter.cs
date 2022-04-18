using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;
using VanDsi.Core.Services;

namespace VanDsi.Api.Filters
{
    public class DuplicateLaborControlFilter<T> : IAsyncActionFilter where T : Labor
    {
        private readonly ILaborService _laborService;

        public DuplicateLaborControlFilter(ILaborService laborService)
        {
            _laborService = laborService;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var labor = context.ActionArguments.Values.FirstOrDefault();
            if (labor != null)
            {
                if (labor is LaborDto laborDto)
                {
                    var haveLaber = _laborService.Where(l =>
                            l.EmployeeId == laborDto.EmployeeId && l.Month == laborDto.Month && l.Year == laborDto.Year)
                        .Any();

                    if (haveLaber)
                        context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(400, $"{laborDto.Month}/{laborDto.Year} Duplicate Labor"));
                    else
                    {
                        await next.Invoke();
                        return;
                    }
                }
                else if (labor is List<LaborDto> laborDtoList)
                {
                    foreach (var laborItem in laborDtoList)
                    {
                        var haveLaber = _laborService.Where(l =>
                                l.EmployeeId == laborItem.EmployeeId && l.Month == laborItem.Month && l.Year == laborItem.Year)
                            .Any();
                        if (!haveLaber) continue;
                        context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(400, $"{laborItem.Month}/{laborItem.Year} Duplicate Labor"));
                        return;
                    }
                    await next.Invoke();
                    return;
                }
                else
                {
                    await next();
                    return;
                }
            }
            else
            {
                await next();
                return;
            }
        }
    }
}
