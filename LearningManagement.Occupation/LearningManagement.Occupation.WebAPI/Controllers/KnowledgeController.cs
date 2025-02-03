using LearningManagement.Occupation.Application.Knowledges.Contracts;
using LearningManagement.Occupation.Application.Knowledges.Dtos;
using LearningManagement.Occupation.Application.Knowledges.Dtos.Create;
using LearningManagement.Occupation.Application.Knowledges.Dtos.Get;

namespace LearningManagement.Occupation.WebAPI.Controllers;

[ApiController]
[Route("api/v1/knowledges")]
public class KnowledgeController(IKnowledgeService knowledgeService) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<CreateKnowledgeResponse>> Create([FromBody] CreateKnowledgeRequest request, CancellationToken cancellationToken) {
        var knowledge = await knowledgeService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = knowledge.Id }, knowledge);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<KnowledgeDto>> GetById(Guid id, CancellationToken cancellationToken) {
        var knowledge = await knowledgeService.GetByIdAsync(id, true, cancellationToken);
        return Ok(knowledge);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResult<KnowledgeDto>>> GetAll([FromQuery] PaginationRequest request,
        [FromQuery] KnowledgeSearchRequest? searchRequest, CancellationToken cancellationToken) {
        var knowledges = await knowledgeService.GetAllAsync(request, searchRequest, true, cancellationToken);
        return Ok(knowledges);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateKnowledgeRequest request, CancellationToken cancellationToken) {
        await knowledgeService.UpdateAsync(id, request, cancellationToken);
        return NoContent(); // 204 - Successful update with no content
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) {
        await knowledgeService.DeleteAsync(id, cancellationToken);
        return NoContent(); // 204 - Successful deletion with no content
    }
}