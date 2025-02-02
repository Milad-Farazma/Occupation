using LearningManagement.Occupation.Application.Technologys.Contracts;
using LearningManagement.Occupation.Application.Technologys.Dtos;
using LearningManagement.Occupation.Application.Technologys.Dtos.Create;
using LearningManagement.Occupation.Application.Technologys.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/technologies")]
public class TechnologyController(ITechnologyService technologyService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateTechnologyResponse>>
        Create([FromBody] CreateTechnologyRequest request, CancellationToken cancellationToken) {
        var technology = await technologyService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = technology.Id }, technology);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<TechnologyDto>> GetById(long id, CancellationToken cancellationToken) {
        var technology = await technologyService.GetByIdAsync(id, true, cancellationToken);
        return Ok(technology);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<TechnologyDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] TechnologySearchRequest? searchRequest, CancellationToken cancellationToken) {
        var technologys = await technologyService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(technologys);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateTechnologyRequest request, CancellationToken cancellationToken) {
        await technologyService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await technologyService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}