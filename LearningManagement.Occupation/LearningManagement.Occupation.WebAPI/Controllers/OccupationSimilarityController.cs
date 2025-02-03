using LearningManagement.Occupation.Application.OccupationSimilarities.Contracts;
using LearningManagement.Occupation.Application.OccupationSimilarities.Dtos;
using LearningManagement.Occupation.Application.OccupationSimilarities.Dtos.Create;
using LearningManagement.Occupation.Application.OccupationSimilarities.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/occupationSimilarities")]
public class OccupationSimilarityController(IOccupationSimilarityService occupationSimilarityService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateOccupationSimilarityResponse>> Create([FromBody] CreateOccupationSimilarityRequest request,
        CancellationToken cancellationToken) {
        var occupationSimilarity = await occupationSimilarityService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = occupationSimilarity.Id }, occupationSimilarity);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OccupationSimilarityDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var occupationSimilarity = await occupationSimilarityService.GetByIdAsync(id, true, cancellationToken);
        return Ok(occupationSimilarity);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<OccupationSimilarityDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] OccupationSimilaritySearchRequest? searchRequest, CancellationToken cancellationToken) {
        var occupationSimilaritys = await occupationSimilarityService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(occupationSimilaritys);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOccupationSimilarityRequest request,
        CancellationToken cancellationToken) {
        await occupationSimilarityService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await occupationSimilarityService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}