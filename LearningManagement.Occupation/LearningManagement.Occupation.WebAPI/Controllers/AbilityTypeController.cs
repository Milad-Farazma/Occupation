using LearningManagement.Occupation.Application.AbilityTypes.Contracts;
using LearningManagement.Occupation.Application.AbilityTypes.Dtos;
using LearningManagement.Occupation.Application.AbilityTypes.Dtos.Create;
using LearningManagement.Occupation.Application.AbilityTypes.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/ability-types")]
public class AbilityTypeController(IAbilityTypeService abilityTypeService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateAbilityTypeResponse>> Create([FromBody] CreateAbilityTypeRequest request,
        CancellationToken cancellationToken) {
        var abilityType = await abilityTypeService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = abilityType.Id }, abilityType);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<AbilityTypeDto>> GetById(long id, CancellationToken cancellationToken) {
        var abilityType = await abilityTypeService.GetByIdAsync(id, true, cancellationToken);
        return Ok(abilityType);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<AbilityTypeDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] AbilityTypeSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var abilityTypes = await abilityTypeService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(abilityTypes);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateAbilityTypeRequest request, CancellationToken cancellationToken) {
        await abilityTypeService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await abilityTypeService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}