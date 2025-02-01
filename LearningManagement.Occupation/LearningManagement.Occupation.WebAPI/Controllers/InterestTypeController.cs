using LearningManagement.Occupation.Application.InterestTypes.Contracts;
using LearningManagement.Occupation.Application.InterestTypes.Dtos;
using LearningManagement.Occupation.Application.InterestTypes.Dtos.Create;
using LearningManagement.Occupation.Application.InterestTypes.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/interest-types")]
public class InterestTypeController(IInterestTypeService interestTypeService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateInterestTypeResponse>> Create([FromBody] CreateInterestTypeRequest request,
        CancellationToken cancellationToken) {
        var interestType = await interestTypeService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = interestType.Id }, interestType);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<InterestTypeDto>> GetById(long id, CancellationToken cancellationToken) {
        var interestType = await interestTypeService.GetByIdAsync(id, true, cancellationToken);
        return Ok(interestType);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<InterestTypeDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] InterestTypeSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var interestTypes = await interestTypeService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(interestTypes);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateInterestTypeRequest request, CancellationToken cancellationToken) {
        await interestTypeService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await interestTypeService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}