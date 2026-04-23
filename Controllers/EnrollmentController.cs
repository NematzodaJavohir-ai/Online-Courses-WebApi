using Application.DTOs.EnrollmentsDTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[ApiController]
[Route("api/enrollments")]
[Authorize] 
public class EnrollmentController(IEnrollmentService service) : BaseController
{
    [HttpPost("enroll/{courseId:int}")]
    public async Task<IActionResult> EnrollAsync(int courseId, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        return HandleResult(await service.EnrollStudentAsync(userId, courseId, ct));
    }

    [HttpGet("my")]
    public async Task<IActionResult> GetMyEnrollmentsAsync(CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        return HandleResult(await service.GetStudentEnrollmentsAsync(userId, ct));
    }

    [HttpPatch("progress")]
    public async Task<IActionResult> UpdateProgressAsync([FromBody] UpdateProgressDto dto, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        return HandleResult(await service.UpdateProgressAsync(userId, dto.CourseId, dto.ProgressPercent, ct));
    }

    [HttpPost("complete/{courseId:int}")]
    public async Task<IActionResult> CompleteAsync(int courseId, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        return HandleResult(await service.CompleteCourseAsync(userId, courseId, ct));
    }
}