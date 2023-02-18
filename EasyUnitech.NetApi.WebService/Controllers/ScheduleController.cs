using System.Globalization;
using EasyUnitech.NetApi.Interfaces;
using EasyUnitech.NetApi.Models;
using EasyUnitech.NetApi.WebService.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EasyUnitech.NetApi.WebService.Controllers;

[Route("schedule")]
[TypeFilter(typeof(UnitechAuthorizationFilter))]
public class ScheduleController : Controller
{
    private readonly IScheduleService _scheduleService;

    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<ScheduleEvent>> GetWeek(DateTime? date)
    {
        return await _scheduleService.GetWeekAsync(date ?? DateTime.Now);
    }

    [HttpGet("day")]
    public async Task<IReadOnlyCollection<ScheduleEvent>> GetDay(DateTime? date)
    {
        return await _scheduleService.GetDayAsync(date ?? DateTime.Now);
    }
}

