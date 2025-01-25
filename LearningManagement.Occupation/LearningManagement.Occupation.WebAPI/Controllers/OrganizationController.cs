using Framework.Pagination;
using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Application.Organizations.Dto;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/organizations")]
public class OrganizationController(IOrganizationService organizationService) : ControllerBase {
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrganizationRequest request, CancellationToken cancellationToken) {
        var organization = await organizationService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = organization.Id }, organization);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<OrganizationDto>> GetById(long id, CancellationToken cancellationToken) {
        var organization = await organizationService.GetByIdWithRelationsAsync(id, cancellationToken);
        return Ok(organization);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<OrganizationDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] OrganizationSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var organizations = await organizationService.GetAllAsync(request, searchRequest, cancellationToken);
        return Ok(organizations);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateOrganizationRequest request, CancellationToken cancellationToken) {
        await organizationService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await organizationService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}