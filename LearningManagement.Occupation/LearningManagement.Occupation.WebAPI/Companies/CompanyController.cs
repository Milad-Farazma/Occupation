using LearningManagement.Occupation.Application.Companies;
using LearningManagement.Occupation.Application.Companies.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Occupation.WebAPI.Companies;

[ApiController]
[Route("api/[controller]")]
public class CompanyController(ICompanyService companyService) : ControllerBase {
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command, CancellationToken cancellationToken) {
        var company = await companyService.CreateAsync(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = company.Id }, company);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<CompanyDto>> GetById(long id, CancellationToken cancellationToken) {
        var company = await companyService.GetByIdAsync(id, cancellationToken);
        if (company == null) return NotFound();
        return Ok(company);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAll(CancellationToken cancellationToken) {
        var companies = await companyService.GetAllAsync(cancellationToken);
        return Ok(companies);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateCompanyCommand command, CancellationToken cancellationToken) {
        // Assuming UpdateCompanyCommand contains the company Id or it can be set in the service
        if (id != command.Id) {
            return BadRequest("Company ID mismatch.");
        }

        await companyService.UpdateAsync(command, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await companyService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}