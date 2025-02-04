using LearningManagement.Occupation.Application.Aliases.Contracts;
using LearningManagement.Occupation.Application.Aliases.Dtos;
using LearningManagement.Occupation.Application.Aliases.Dtos.Create;
using LearningManagement.Occupation.Application.Aliases.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/aliases")]
public class AliasController(IAliasService aliasService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateAliasResponse>> Create([FromBody] CreateAliasRequest request, CancellationToken cancellationToken) {
        var alias = await aliasService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = alias.Id }, alias);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AliasDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var alias = await aliasService.GetByIdAsync(id, true, cancellationToken);
        return Ok(alias);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<AliasDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] AliasSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var alias = await aliasService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(alias);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAliasRequest request, CancellationToken cancellationToken) {
        await aliasService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await aliasService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}