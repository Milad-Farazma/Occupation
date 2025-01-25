using Framework.Pagination;
using LearningManagement.Occupation.Application.OrganizationTypes.Contracts;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/OrganizationTypes")]
public class OrganizationTypeController(IOrganizationTypeService organizationTypeService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateOrganizationTypeResponse>> Create([FromBody] CreateOrganizationTypeRequest request, CancellationToken cancellationToken) {
        var organizationType = await organizationTypeService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = organizationType.Id }, organizationType);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<OrganizationTypeDto>> GetById(long id, CancellationToken cancellationToken) {
        var organizationType = await organizationTypeService.GetByIdWithRelationsAsync(id, cancellationToken);
        return Ok(organizationType);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<OrganizationTypeDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] OrganizationTypeSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var organizationTypes = await organizationTypeService.GetAllWithRelationsAsync(request, searchRequest, cancellationToken);
        return Ok(organizationTypes);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateOrganizationTypeRequest request,
        CancellationToken cancellationToken) {
        await organizationTypeService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await organizationTypeService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}