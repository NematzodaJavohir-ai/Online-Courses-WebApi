using Application.DTOs.LessonDTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[ApiController]
[Route("api/lessons")]
public class LessonController(ILessonService service) : BaseController
{
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(int id, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        return HandleResult(await service.GetByIdAsync(id, userId, ct));
    }

    [HttpGet("course/{courseId:int}")]
    public async Task<IActionResult> GetByCourseAsync(int courseId, CancellationToken ct)
    {
        return HandleResult(await service.GetLessonsByCourseAsync(courseId, ct));
    }

    [HttpPost]
    [Authorize(Roles = "Instructor,Admin")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateLessonDto dto, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        return HandleResult(await service.CreateAsync(dto, userId, ct));
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Instructor,Admin")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateLessonDto dto, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        return HandleResult(await service.UpdateAsync(id, dto, userId, ct));
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Instructor,Admin")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        return HandleResult(await service.DeleteAsync(id, userId, ct));
    }
}