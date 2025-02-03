using LearningManagement.Occupation.Application.JobOutLooks.Contracts;
using LearningManagement.Occupation.Application.JobOutLooks.Dtos;
using LearningManagement.Occupation.Application.JobOutLooks.Dtos.Create;
using LearningManagement.Occupation.Application.JobOutLooks.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/job-outLooks")]
public class JobOutLookController(IJobOutLookService jobOutLookService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateJobOutLookResponse>>
        Create([FromBody] CreateJobOutLookRequest request, CancellationToken cancellationToken) {
        var jobOutLook = await jobOutLookService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = jobOutLook.Id }, jobOutLook);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<JobOutLookDto>> GetById(long id, CancellationToken cancellationToken) {
        var jobOutLook = await jobOutLookService.GetByIdAsync(id, true, cancellationToken);
        return Ok(jobOutLook);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<JobOutLookDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] JobOutLookSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var jobOutLooks = await jobOutLookService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(jobOutLooks);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateJobOutLookRequest request, CancellationToken cancellationToken) {
        await jobOutLookService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await jobOutLookService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}