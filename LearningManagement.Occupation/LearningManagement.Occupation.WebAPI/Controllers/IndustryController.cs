using LearningManagement.Occupation.Application.Industries.Contracts;
using LearningManagement.Occupation.Application.Industries.Dtos;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/Industries")]
public class IndustryController(IIndustryService industryService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateIndustryResponse>> Create([FromBody] CreateIndustryRequest request, CancellationToken cancellationToken) {
        var industry = await industryService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = industry.Id }, industry);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<IndustryDto>> GetById(long id, CancellationToken cancellationToken) {
        var industry = await industryService.GetByIdAsync(id, true, cancellationToken);
        return Ok(industry);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<IndustryDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] IndustrySearchRequest? searchRequest, CancellationToken cancellationToken) {
        var industrys = await industryService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(industrys);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateIndustryRequest request, CancellationToken cancellationToken) {
        await industryService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken) {
        await industryService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}