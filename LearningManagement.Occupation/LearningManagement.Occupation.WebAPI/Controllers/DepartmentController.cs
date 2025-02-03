using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Dtos;
using LearningManagement.Occupation.Application.Departments.Dtos.Create;
using LearningManagement.Occupation.Application.Departments.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/departments")]
public class DepartmentController(IDepartmentService departmentService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateDepartmentResponse>>
        Create([FromBody] CreateDepartmentRequest request, CancellationToken cancellationToken) {
        var department = await departmentService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DepartmentDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var department = await departmentService.GetByIdAsync(id, true, cancellationToken);
        return Ok(department);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<DepartmentDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] DepartmentSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var departments = await departmentService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(departments);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDepartmentRequest request, CancellationToken cancellationToken) {
        await departmentService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await departmentService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}