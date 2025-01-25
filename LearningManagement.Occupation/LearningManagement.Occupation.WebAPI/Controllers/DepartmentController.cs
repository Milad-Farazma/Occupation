using Framework.Pagination;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Dto;
using LearningManagement.Occupation.Application.Departments.Dto.Create;
using LearningManagement.Occupation.Application.Departments.Dto.Update;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/organizations/departments")]
public class DepartmentController(IDepartmentService departmentService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateDepartmentResponse>>
        Create([FromBody] CreateDepartmentRequest request, CancellationToken cancellationToken) {
        var organization = await departmentService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = organization.Id }, organization);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<DepartmentDto>> GetById(long id, CancellationToken cancellationToken) {
        var organization = await departmentService.GetByIdAsync(id, cancellationToken);
        return Ok(organization);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<DepartmentDto>>>
        GetAll([FromQuery] PaginationRequest request, CancellationToken cancellationToken) {
        var organizations = await departmentService.GetAllAsync(request, cancellationToken);
        return Ok(organizations);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateDepartmentRequest request, CancellationToken cancellationToken) {
        await departmentService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await departmentService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}