using LearningManagement.Occupation.Application.KnowledgeTypes.Contracts;
using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos;
using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Create;
using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/knowledge-types")]
public class KnowledgeTypeController(IKnowledgeTypeService knowledgeTypeService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateKnowledgeTypeResponse>> Create([FromBody] CreateKnowledgeTypeRequest request,
        CancellationToken cancellationToken) {
        var knowledgeType = await knowledgeTypeService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = knowledgeType.Id }, knowledgeType);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<KnowledgeTypeDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var knowledgeType = await knowledgeTypeService.GetByIdAsync(id, true, cancellationToken);
        return Ok(knowledgeType);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<KnowledgeTypeDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] KnowledgeTypeSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var knowledgeTypes = await knowledgeTypeService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(knowledgeTypes);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateKnowledgeTypeRequest request, CancellationToken cancellationToken) {
        await knowledgeTypeService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await knowledgeTypeService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}