using LearningManagement.Occupation.Application.TechnologyTypes.Contracts;
using LearningManagement.Occupation.Application.TechnologyTypes.Dtos;
using LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Create;
using LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/technology-types")]
public class TechnologyTypeController(ITechnologyTypeService technologyTypeService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateTechnologyTypeResponse>> Create([FromBody] CreateTechnologyTypeRequest request,
        CancellationToken cancellationToken) {
        var technologyType = await technologyTypeService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = technologyType.Id }, technologyType);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<TechnologyTypeDto>> GetById(long id, CancellationToken cancellationToken) {
        var technologyType = await technologyTypeService.GetByIdAsync(id, true, cancellationToken);
        return Ok(technologyType);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<TechnologyTypeDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] TechnologyTypeSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var technologyTypes = await technologyTypeService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(technologyTypes);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateTechnologyTypeRequest request,
        CancellationToken cancellationToken) {
        await technologyTypeService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await technologyTypeService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}