using LearningManagement.Occupation.Application.OrganizationTypes.Contracts;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Create;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Get;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Update;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/organization-types")]
public class OrganizationTypeController(IOrganizationTypeService organizationTypeService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateOrganizationTypeResponse>> Create([FromBody] CreateOrganizationTypeRequest request,
        CancellationToken cancellationToken) {
        var organizationType = await organizationTypeService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = organizationType.Id }, organizationType);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<OrganizationTypeDto>> GetById(long id, CancellationToken cancellationToken) {
        var organizationType = await organizationTypeService.GetByIdAsync(id, true, cancellationToken);
        return Ok(organizationType);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<OrganizationTypeDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] OrganizationTypeSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var organizationTypes = await organizationTypeService.GetAllAsync(request, searchRequest, true, cancellationToken);
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