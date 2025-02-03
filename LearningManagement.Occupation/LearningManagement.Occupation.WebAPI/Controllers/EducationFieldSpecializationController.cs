using LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Create;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Get;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Update;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/education-field-specializations")]
public class EducationFieldSpecializationController(IEducationFieldSpecializationService educationFieldSpecializationService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateEducationFieldSpecializationResponse>> Create([FromBody] CreateEducationFieldSpecializationRequest request,
        CancellationToken cancellationToken) {
        var educationFieldSpecialization = await educationFieldSpecializationService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = educationFieldSpecialization.Id }, educationFieldSpecialization);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EducationFieldSpecializationDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var educationFieldSpecialization = await educationFieldSpecializationService.GetByIdAsync(id, true, cancellationToken);
        return Ok(educationFieldSpecialization);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<EducationFieldSpecializationDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] EducationFieldSpecializationSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var educationFieldSpecializations =
            await educationFieldSpecializationService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(educationFieldSpecializations);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEducationFieldSpecializationRequest request,
        CancellationToken cancellationToken) {
        await educationFieldSpecializationService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await educationFieldSpecializationService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}