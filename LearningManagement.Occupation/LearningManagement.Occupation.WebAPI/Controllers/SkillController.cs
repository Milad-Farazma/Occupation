using LearningManagement.Occupation.Application.Skills.Contracts;
using LearningManagement.Occupation.Application.Skills.Dtos;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/skills")]
public class SkillController(ISkillService skillService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateSkillResponse>> Create([FromBody] CreateSkillRequest request, CancellationToken cancellationToken) {
        var skill = await skillService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = skill.Id }, skill);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<SkillDto>> GetById(long id, CancellationToken cancellationToken) {
        var skill = await skillService.GetByIdAsync(id, true, cancellationToken);
        return Ok(skill);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<SkillDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] SkillSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var skills = await skillService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(skills);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateSkillRequest request, CancellationToken cancellationToken) {
        await skillService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await skillService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}