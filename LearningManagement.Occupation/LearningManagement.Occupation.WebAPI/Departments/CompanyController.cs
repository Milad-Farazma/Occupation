using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Dto;

namespace LearningManagement.Occupation.WebAPI.Departments;

[ApiController]
[Route("api/v1/companies/Departments")]
public class DepartmentsController(IDepartmentService companyService) : ControllerBase {
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDepartmentRequest request, CancellationToken cancellationToken) {
        var company = await companyService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = company.Id }, company);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<DepartmentDto>> GetById(long id, CancellationToken cancellationToken) {
        var company = await companyService.GetByIdAsync(id, cancellationToken);
        if (company == null) return NotFound();
        return Ok(company);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll(CancellationToken cancellationToken) {
        var companies = await companyService.GetAllAsync(cancellationToken);
        return Ok(companies);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateDepartmentRequest request, CancellationToken cancellationToken) {
        await companyService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await companyService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}