using Application.DTOs.LessonDTOs;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace CrmWebApi.Controllers;

[ApiController]
[Route("api/lessons")]
[Authorize]
public class LessonController(ILessonService service) : BaseController
{
    [HttpGet("course/{courseId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByCourseIdAsync(int courseId)
    {
        return HandleResult(await service.GetLessonsByCourseIdAsync(courseId));
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return HandleResult(await service.GetLessonByIdAsync(id));
    }

    [HttpPost("course/{courseId:int}")]
    public async Task<IActionResult> CreateAsync(int courseId, CreateLessonDto dto)
    {
        return HandleResult(await service.CreateLessonAsync(courseId, dto));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateLessonDto dto)
    {
        return HandleResult(await service.UpdateLessonAsync(id, dto));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return HandleResult(await service.DeleteLessonAsync(id));
    }
}