using LearningManagement.Occupation.Application.JobPositions.Contracts;
using LearningManagement.Occupation.Application.JobPositions.Dtos;
using LearningManagement.Occupation.Application.JobPositions.Dtos.Create;
using LearningManagement.Occupation.Application.JobPositions.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/job-positions")]
public class JobPositionController(IJobPositionService jobPositionService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateJobPositionResponse>> Create([FromBody] CreateJobPositionRequest request,
        CancellationToken cancellationToken) {
        var jobPosition = await jobPositionService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = jobPosition.Id }, jobPosition);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<JobPositionDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var jobPosition = await jobPositionService.GetByIdAsync(id, true, cancellationToken);
        return Ok(jobPosition);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<JobPositionDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] JobPositionSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var jobPositions = await jobPositionService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(jobPositions);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateJobPositionRequest request, CancellationToken cancellationToken) {
        await jobPositionService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await jobPositionService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}