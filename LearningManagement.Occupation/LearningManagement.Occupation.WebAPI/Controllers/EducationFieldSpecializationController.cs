using Framework.Pagination;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/EducationFieldSpecializations")]
public class EducationFieldSpecializationController(IEducationFieldSpecializationService educationFieldSpecializationService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateEducationFieldSpecializationResponse>> Create([FromBody] CreateEducationFieldSpecializationRequest request,
        CancellationToken cancellationToken) {
        var educationFieldSpecialization = await educationFieldSpecializationService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = educationFieldSpecialization.Id }, educationFieldSpecialization);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<EducationFieldSpecializationDto>> GetById(long id, CancellationToken cancellationToken) {
        var educationFieldSpecialization = await educationFieldSpecializationService.GetByIdWithRelationsAsync(id, cancellationToken);
        return Ok(educationFieldSpecialization);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<EducationFieldSpecializationDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] EducationFieldSpecializationSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var educationFieldSpecializations =
            await educationFieldSpecializationService.GetAllWithRelationsAsync(request, searchRequest, cancellationToken);
        return Ok(educationFieldSpecializations);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateEducationFieldSpecializationRequest request,
        CancellationToken cancellationToken) {
        await educationFieldSpecializationService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await educationFieldSpecializationService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}