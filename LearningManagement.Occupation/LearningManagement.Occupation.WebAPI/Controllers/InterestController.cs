using LearningManagement.Occupation.Application.Interests.Contracts;
using LearningManagement.Occupation.Application.Interests.Dtos;
using LearningManagement.Occupation.Application.Interests.Dtos.Create;
using LearningManagement.Occupation.Application.Interests.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/interests")]
public class InterestController(IInterestService interestService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateInterestResponse>> Create([FromBody] CreateInterestRequest request, CancellationToken cancellationToken) {
        var interest = await interestService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = interest.Id }, interest);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<InterestDto>> GetById(long id, CancellationToken cancellationToken) {
        var interest = await interestService.GetByIdAsync(id, true, cancellationToken);
        return Ok(interest);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<InterestDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] InterestSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var interests = await interestService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(interests);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateInterestRequest request, CancellationToken cancellationToken) {
        await interestService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await interestService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}