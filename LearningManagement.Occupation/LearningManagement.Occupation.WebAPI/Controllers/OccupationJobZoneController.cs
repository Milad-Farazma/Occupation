using LearningManagement.Occupation.Application.OccupationJobZones.Contracts;
using LearningManagement.Occupation.Application.OccupationJobZones.Dtos;
using LearningManagement.Occupation.Application.OccupationJobZones.Dtos.Create;
using LearningManagement.Occupation.Application.OccupationJobZones.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/occupationJobZones")]
public class OccupationJobZoneController(IOccupationJobZoneService occupationJobZoneService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateOccupationJobZoneResponse>> Create([FromBody] CreateOccupationJobZoneRequest request,
        CancellationToken cancellationToken) {
        var occupationJobZone = await occupationJobZoneService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = occupationJobZone.Id }, occupationJobZone);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<OccupationJobZoneDto>> GetById(long id, CancellationToken cancellationToken) {
        var occupationJobZone = await occupationJobZoneService.GetByIdAsync(id, true, cancellationToken);
        return Ok(occupationJobZone);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<OccupationJobZoneDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] OccupationJobZoneSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var occupationJobZones = await occupationJobZoneService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(occupationJobZones);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateOccupationJobZoneRequest request,
        CancellationToken cancellationToken) {
        await occupationJobZoneService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await occupationJobZoneService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}