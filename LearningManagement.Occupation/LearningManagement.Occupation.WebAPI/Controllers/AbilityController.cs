using LearningManagement.Occupation.Application.Abilities.Contracts;
using LearningManagement.Occupation.Application.Abilities.Dtos;
using LearningManagement.Occupation.Application.Abilities.Dtos.Create;
using LearningManagement.Occupation.Application.Abilities.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/abilities")]
public class AbilityController(IAbilityService abilityService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateAbilityResponse>> Create([FromBody] CreateAbilityRequest request, CancellationToken cancellationToken) {
        var ability = await abilityService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = ability.Id }, ability);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<AbilityDto>> GetById(long id, CancellationToken cancellationToken) {
        var ability = await abilityService.GetByIdAsync(id, true, cancellationToken);
        return Ok(ability);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<AbilityDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] AbilitySearchRequest? searchRequest, CancellationToken cancellationToken) {
        var abilitys = await abilityService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(abilitys);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateAbilityRequest request, CancellationToken cancellationToken) {
        await abilityService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await abilityService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}