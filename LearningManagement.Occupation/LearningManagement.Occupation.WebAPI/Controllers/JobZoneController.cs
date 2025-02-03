using LearningManagement.Occupation.Application.JobZones.Contracts;
using LearningManagement.Occupation.Application.JobZones.Dtos;
using LearningManagement.Occupation.Application.JobZones.Dtos.Create;
using LearningManagement.Occupation.Application.JobZones.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/job-zones")]
public class JobZoneController(IJobZoneService jobZoneService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateJobZoneResponse>> Create([FromBody] CreateJobZoneRequest request, CancellationToken cancellationToken) {
        var jobZone = await jobZoneService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = jobZone.Id }, jobZone);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<JobZoneDto>> GetById(long id, CancellationToken cancellationToken) {
        var jobZone = await jobZoneService.GetByIdAsync(id, true, cancellationToken);
        return Ok(jobZone);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<JobZoneDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] JobZoneSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var jobZones = await jobZoneService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(jobZones);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateJobZoneRequest request, CancellationToken cancellationToken) {
        await jobZoneService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await jobZoneService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}