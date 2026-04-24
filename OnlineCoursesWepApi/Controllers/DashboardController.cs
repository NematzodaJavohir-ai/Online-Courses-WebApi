using Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace CrmWebApi.Controllers;

[ApiController]
[Route("api/dashboard")]
[Authorize(Roles = "Admin")]
public class DashboardController(IDashboardService service) : BaseController
{
    [HttpGet("summary")]
    public async Task<IActionResult> GetSummaryAsync()
    {
        return HandleResult(await service.GetSummaryAsync());
    }

    [HttpGet("top-courses")]
    public async Task<IActionResult> GetTopCoursesAsync()
    {
        return HandleResult(await service.GetTopCoursesAsync());
    }

    [HttpGet("enrollments-monthly")]
    public async Task<IActionResult> GetEnrollmentsByMonthAsync()
    {
        return HandleResult(await service.GetEnrollmentsByMonthAsync());
    }
}