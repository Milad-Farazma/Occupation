using LearningManagement.Occupation.Application.SeniorityLevels.Contracts;
using LearningManagement.Occupation.Application.SeniorityLevels.Dtos;
using LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Create;
using LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/seniority-level")]
public class SeniorityLevelController(ISeniorityLevelService seniorityLevelService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateSeniorityLevelResponse>> Create([FromBody] CreateSeniorityLevelRequest request,
        CancellationToken cancellationToken) {
        var seniorityLevel = await seniorityLevelService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = seniorityLevel.Id }, seniorityLevel);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SeniorityLevelDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var seniorityLevel = await seniorityLevelService.GetByIdAsync(id, true, cancellationToken);
        return Ok(seniorityLevel);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<SeniorityLevelDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] SeniorityLevelSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var seniorityLevels = await seniorityLevelService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(seniorityLevels);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSeniorityLevelRequest request,
        CancellationToken cancellationToken) {
        await seniorityLevelService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await seniorityLevelService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}