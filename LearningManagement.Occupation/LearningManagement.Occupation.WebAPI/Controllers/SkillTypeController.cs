using LearningManagement.Occupation.Application.SkillTypes.Contracts;
using LearningManagement.Occupation.Application.SkillTypes.Dtos;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/SkillTypes")]
public class SkillTypeController(ISkillTypeService skillTypeService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateSkillTypeResponse>> Create([FromBody] CreateSkillTypeRequest request, CancellationToken cancellationToken) {
        var skillType = await skillTypeService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = skillType.Id }, skillType);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SkillTypeDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var skillType = await skillTypeService.GetByIdAsync(id, true, cancellationToken);
        return Ok(skillType);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<SkillTypeDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] SkillTypeSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var skillTypes = await skillTypeService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(skillTypes);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSkillTypeRequest request, CancellationToken cancellationToken) {
        await skillTypeService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await skillTypeService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}