using LearningManagement.Occupation.Application.JobClassifications.Contracts;
using LearningManagement.Occupation.Application.JobClassifications.Dtos;
using LearningManagement.Occupation.Application.JobClassifications.Dtos.Create;
using LearningManagement.Occupation.Application.JobClassifications.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/job-classifications")]
public class JobClassificationController(IJobClassificationService jobClassificationService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateJobClassificationResponse>> Create([FromBody] CreateJobClassificationRequest request,
        CancellationToken cancellationToken) {
        var jobClassification = await jobClassificationService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = jobClassification.Id }, jobClassification);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<JobClassificationDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var jobClassification = await jobClassificationService.GetByIdAsync(id, true, cancellationToken);
        return Ok(jobClassification);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<JobClassificationDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] JobClassificationSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var jobClassifications = await jobClassificationService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(jobClassifications);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateJobClassificationRequest request,
        CancellationToken cancellationToken) {
        await jobClassificationService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await jobClassificationService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}