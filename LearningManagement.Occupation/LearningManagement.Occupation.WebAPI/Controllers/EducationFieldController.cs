using Framework.Pagination;
using LearningManagement.Occupation.Application.EducationFields.Contracts;
using LearningManagement.Occupation.Application.EducationFields.Dtos;
using LearningManagement.Occupation.Application.EducationFields.Dtos.Create;
using LearningManagement.Occupation.Application.EducationFields.Dtos.Get;
using LearningManagement.Occupation.Application.EducationFields.Dtos.Update;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/education-fields")]
public class EducationFieldController(IEducationFieldService educationFieldService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateEducationFieldResponse>> Create([FromBody] CreateEducationFieldRequest request,
        CancellationToken cancellationToken) {
        var educationField = await educationFieldService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = educationField.Id }, educationField);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<EducationFieldDto>> GetById(long id, CancellationToken cancellationToken) {
        var educationField = await educationFieldService.GetByIdWithRelationsAsync(id, cancellationToken);
        return Ok(educationField);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<EducationFieldDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] EducationFieldSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var educationFields = await educationFieldService.GetAllWithRelationsAsync(request, searchRequest, cancellationToken);
        return Ok(educationFields);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateEducationFieldRequest request,
        CancellationToken cancellationToken) {
        await educationFieldService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await educationFieldService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}