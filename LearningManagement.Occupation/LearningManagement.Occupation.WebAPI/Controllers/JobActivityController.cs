using LearningManagement.Occupation.Application.JobActivities.Contracts;
using LearningManagement.Occupation.Application.JobActivities.Dtos;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/job-activities")]
public class JobActivityController(IJobActivityService jobActivitiesService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateJobActivityResponse>> Create([FromBody] CreateJobActivityRequest request,
        CancellationToken cancellationToken) {
        var jobActivities = await jobActivitiesService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = jobActivities.Id }, jobActivities);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<JobActivityDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var jobActivities = await jobActivitiesService.GetByIdAsync(id, true, cancellationToken);
        return Ok(jobActivities);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<JobActivityDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] JobActivitySearchRequest? searchRequest, CancellationToken cancellationToken) {
        var jobActivitiess = await jobActivitiesService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(jobActivitiess);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateJobActivityRequest request, CancellationToken cancellationToken) {
        await jobActivitiesService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await jobActivitiesService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}