using Application.DTOs.ReviewDTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewController(IReviewService service) : BaseController
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAsync([FromBody] CreateReviewDto dto, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        return HandleResult(await service.AddReviewAsync(dto, userId, ct));
    }

    [HttpGet("course/{courseId:int}")]
    public async Task<IActionResult> GetByCourseAsync(int courseId, CancellationToken ct)
    {
        return HandleResult(await service.GetCourseReviewsAsync(courseId, ct));
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value ?? "";
        
        return HandleResult(await service.DeleteReviewAsync(id, userId, userRole, ct));
    }
}