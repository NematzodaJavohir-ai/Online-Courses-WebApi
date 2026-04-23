using Application.DTOs.CourseDTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Controllers;

namespace CrmWebApi.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController(ICourseService service) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] CourseFilterDto filter, CancellationToken ct)
    {
        return HandleResult(await service.GetAllAsync(filter, ct));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id, CancellationToken ct)
    {
        return HandleResult(await service.GetByIdAsync(id, ct));
    }

    [HttpPost]
    [Authorize(Roles = "Instructor,Admin")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCourseDto dto, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        return HandleResult(await service.CreateAsync(dto, userId, ct));
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Instructor,Admin")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCourseDto dto, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value ?? "";
        
        return HandleResult(await service.UpdateAsync(id, dto, userId, userRole, ct));
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Instructor,Admin")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value ?? "";

        return HandleResult(await service.DeleteAsync(id, userId, userRole, ct));
    }


    [HttpPatch("{id:int}/status")]
    [Authorize(Roles = "Instructor,Admin")]
    public async Task<IActionResult> TogglePublishStatusAsync(int id, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value ?? "";
        
        return HandleResult(await service.TogglePublishStatusAsync(id, userId,ct));
    }
}