using LearningManagement.Occupation.Application.EducationDegrees.Contracts;
using LearningManagement.Occupation.Application.EducationDegrees.Dtos;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/education-degree")]
public class EducationDegreeController(IEducationDegreeService educationDegreeService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateEducationDegreeResponse>> Create([FromBody] CreateEducationDegreeRequest request,
        CancellationToken cancellationToken) {
        var educationDegree = await educationDegreeService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = educationDegree.Id }, educationDegree);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<EducationDegreeDto>> GetById(long id, CancellationToken cancellationToken) {
        var educationDegree = await educationDegreeService.GetByIdAsync(id, true, cancellationToken);
        return Ok(educationDegree);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<EducationDegreeDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] EducationDegreeSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var educationDegrees = await educationDegreeService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(educationDegrees);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateEducationDegreeRequest request,
        CancellationToken cancellationToken) {
        await educationDegreeService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await educationDegreeService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}