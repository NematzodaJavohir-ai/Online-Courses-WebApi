using Application.DTOs.DashboardDTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Controllers;

namespace CrmWebApi.Controllers;

[ApiController]
[Route("api/dashboard")]
[Authorize(Roles = "Admin")]
public class DashboardController(IDashboardService service) : BaseController
{

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummaryAsync(CancellationToken ct)
    {
        return HandleResult(await service.GetSummaryAsync(ct));
    }

    [HttpGet("top-courses")]
    public async Task<IActionResult> GetTopCoursesAsync(CancellationToken ct)
    {
        return HandleResult(await service.GetTopCoursesAsync(ct));
    }
    [HttpGet("enrollments-by-month")]
    public async Task<IActionResult> GetEnrollmentsByMonthAsync(CancellationToken ct)
    {
        return HandleResult(await service.GetEnrollmentsByMonthAsync(ct));
    }
    [HttpGet("revenue-by-category")]
    public async Task<IActionResult> GetRevenueByCategoryAsync(CancellationToken ct)
    {
        return HandleResult(await service.GetRevenueByCategoryAsync(ct));
    }
    [HttpGet("completion-rate")]
    public async Task<IActionResult> GetCompletionRatesAsync(CancellationToken ct)
    {
        return HandleResult(await service.GetCompletionRatesAsync(ct));
    }

    
    [HttpGet("instructor/{instructorId:int}")]
    [Authorize(Roles = "Admin,Instructor")]
    public async Task<IActionResult> GetInstructorStatsAsync(int instructorId, CancellationToken ct)
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        var currentUserRole = User.FindFirst(ClaimTypes.Role)?.Value ?? "";
        return HandleResult(await service.GetInstructorStatsAsync(instructorId, currentUserId, currentUserRole, ct));
    }

    [HttpGet("students-progress")]
    public async Task<IActionResult> GetStudentsProgressSummaryAsync(CancellationToken ct)
    {
        return HandleResult(await service.GetStudentsProgressSummaryAsync(ct));
    }

    [HttpGet("ratings-distribution")]
    public async Task<IActionResult> GetRatingsDistributionAsync(CancellationToken ct)
    {
        return HandleResult(await service.GetRatingsDistributionAsync(ct));
    }
}