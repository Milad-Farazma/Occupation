using LearningManagement.Occupation.Application.Occupations.Contracts;
using LearningManagement.Occupation.Application.Occupations.Dtos;
using LearningManagement.Occupation.Application.Occupations.Dtos.Create;
using LearningManagement.Occupation.Application.Occupations.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/occupations")]
public class OccupationController(IOccupationService occupationService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateOccupationResponse>>
        Create([FromBody] CreateOccupationRequest request, CancellationToken cancellationToken) {
        var occupation = await occupationService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = occupation.Id }, occupation);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OccupationDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var occupation = await occupationService.GetByIdAsync(id, true, cancellationToken);
        return Ok(occupation);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<OccupationDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] OccupationSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var occupations = await occupationService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(occupations);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOccupationRequest request, CancellationToken cancellationToken) {
        await occupationService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await occupationService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}