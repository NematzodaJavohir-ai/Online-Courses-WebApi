using Application.DTOs.CategoryDTOS;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace CrmWebApi.Controllers;

[ApiController]
[Route("api/categories")]
[Authorize]
public class CategoryController(ICategoryService service) : BaseController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        return HandleResult(await service.GetAllCategoriesAsync());
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return HandleResult(await service.GetCategoryByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCategoryDto dto)
    {
        return HandleResult(await service.CreateCategoryAsync(dto));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateCategoryDto dto)
    {
        return HandleResult(await service.UpdateCategoryAsync(id, dto));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return HandleResult(await service.DeleteCategoryAsync(id));
    }
}