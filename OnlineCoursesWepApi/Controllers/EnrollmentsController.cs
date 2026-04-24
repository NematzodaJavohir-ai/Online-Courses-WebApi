using Application.DTOs.EnrollmentDTOs;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using System.Security.Claims;

namespace CrmWebApi.Controllers;

[ApiController]
[Route("api/enrollments")]
[Authorize]
public class EnrollmentController(IEnrollmentService service) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return HandleResult(await service.GetAllEnrollmentsAsync());
    }

    [HttpGet("my")]
    public async Task<IActionResult> GetMyEnrollmentsAsync()
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return HandleResult(await service.GetMyEnrollmentsAsync(studentId));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEnrollmentDto dto)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return HandleResult(await service.CreateEnrollmentAsync(dto, studentId));
    }

    [HttpPut("{id:int}/progress")]
    public async Task<IActionResult> UpdateProgressAsync(int id, UpdateEnrollmentDto dto)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return HandleResult(await service.UpdateProgressAsync(id, dto, studentId));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return HandleResult(await service.DeleteEnrollmentAsync(id, studentId));
    }
}