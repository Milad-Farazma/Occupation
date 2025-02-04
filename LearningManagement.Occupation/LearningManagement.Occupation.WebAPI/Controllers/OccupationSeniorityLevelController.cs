using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Contracts;
using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos;
using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos.Create;
using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/occupationSeniorityLevels")]
public class OccupationSeniorityLevelController(IOccupationSeniorityLevelService occupationSeniorityLevelService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateOccupationSeniorityLevelResponse>> Create([FromBody] CreateOccupationSeniorityLevelRequest request,
        CancellationToken cancellationToken) {
        var occupationSeniorityLevel = await occupationSeniorityLevelService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = occupationSeniorityLevel.Id }, occupationSeniorityLevel);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OccupationSeniorityLevelDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var occupationSeniorityLevel = await occupationSeniorityLevelService.GetByIdAsync(id, true, cancellationToken);
        return Ok(occupationSeniorityLevel);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<OccupationSeniorityLevelDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] OccupationSeniorityLevelSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var occupationSeniorityLevels = await occupationSeniorityLevelService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(occupationSeniorityLevels);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOccupationSeniorityLevelRequest request,
        CancellationToken cancellationToken) {
        await occupationSeniorityLevelService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await occupationSeniorityLevelService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}