using LearningManagement.Occupation.Application.Company;
using LearningManagement.Occupation.Application.Company.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Occupation.WebAPI.Company;

[ApiController]
[Route("api/[controller]")]
public class CompanyController(ICompanyService companyService) : ControllerBase {
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command) {
        var company = await companyService.CreateAsync(command);
        return CreatedAtAction(nameof(GetById), new { id = company.Id }, company);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<CompanyDto>> GetById(long id) {
        var company = await companyService.GetByIdAsync(id);
        if (company == null) return NotFound();
        return Ok(company);
    }
}