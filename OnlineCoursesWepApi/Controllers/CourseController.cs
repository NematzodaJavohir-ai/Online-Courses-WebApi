using Application.DTOs.CourseDTOs;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using System.Security.Claims;

namespace CrmWebApi.Controllers;

[ApiController]
[Route("api/courses")]
[Authorize]
public class CourseController(ICourseService service) : BaseController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetCoursesAsync([FromQuery] CourseFilterDto filter)
    {
        return HandleResult(await service.GetCoursesAsync(filter));
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return HandleResult(await service.GetCourseByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCourseDto dto)
    {
        var instructorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return HandleResult(await service.CreateCourseAsync(dto, instructorId));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateCourseDto dto)
    {
        return HandleResult(await service.UpdateCourseAsync(id, dto));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return HandleResult(await service.DeleteCourseAsync(id));
    }

    [HttpPatch("{id:int}/toggle-publish")]
    public async Task<IActionResult> TogglePublishAsync(int id)
    {
        return HandleResult(await service.TogglePublishAsync(id));
    }
}