using Application.DTOs.ReviewDTOs;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using System.Security.Claims;

namespace CrmWebApi.Controllers;

[ApiController]
[Route("api/reviews")]
[Authorize]
public class ReviewController(IReviewService service) : BaseController
{
    [HttpGet("course/{courseId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByCourseIdAsync(int courseId)
    {
        return HandleResult(await service.GetReviewsByCourseIdAsync(courseId));
    }

    [HttpPost("course/{courseId:int}")]
    public async Task<IActionResult> CreateAsync(int courseId, CreateReviewDto dto)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return HandleResult(await service.CreateReviewAsync(courseId, dto, studentId));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateReviewDto dto)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return HandleResult(await service.UpdateReviewAsync(id, dto, studentId));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return HandleResult(await service.DeleteReviewAsync(id, studentId));
    }
}