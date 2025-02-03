using LearningManagement.Occupation.Application.Personalities.Contracts;
using LearningManagement.Occupation.Application.Personalities.Dtos;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/Personalitys")]
public class PersonalityController(IPersonalityService personalitiesService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreatePersonalityResponse>> Create([FromBody] CreatePersonalityRequest request,
        CancellationToken cancellationToken) {
        var personalities = await personalitiesService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = personalities.Id }, personalities);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PersonalityDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var personalities = await personalitiesService.GetByIdAsync(id, true, cancellationToken);
        return Ok(personalities);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<PersonalityDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] PersonalitySearchRequest? searchRequest, CancellationToken cancellationToken) {
        var personalitiess = await personalitiesService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(personalitiess);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePersonalityRequest request, CancellationToken cancellationToken) {
        await personalitiesService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await personalitiesService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}