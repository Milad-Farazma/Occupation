using LearningManagement.Occupation.Application.DepartmentTypes.Contracts;
using LearningManagement.Occupation.Application.DepartmentTypes.Dtos;
using LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Create;
using LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/department-types")]
public class DepartmentTypeController(IDepartmentTypeService departmentTypeService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateDepartmentTypeResponse>> Create([FromBody] CreateDepartmentTypeRequest request,
        CancellationToken cancellationToken) {
        var departmentType = await departmentTypeService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = departmentType.Id }, departmentType);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DepartmentTypeDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var departmentType = await departmentTypeService.GetByIdAsync(id, true, cancellationToken);
        return Ok(departmentType);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<DepartmentTypeDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] DepartmentTypeSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var departmentTypes = await departmentTypeService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(departmentTypes);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDepartmentTypeRequest request,
        CancellationToken cancellationToken) {
        await departmentTypeService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await departmentTypeService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}