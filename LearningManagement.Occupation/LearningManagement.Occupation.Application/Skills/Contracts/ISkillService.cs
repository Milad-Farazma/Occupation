using LearningManagement.Occupation.Application.Skills.Dtos;

namespace LearningManagement.Occupation.Application.Skills.Contracts;

public interface ISkillService {
    Task<CreateSkillResponse> CreateAsync(CreateSkillRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<SkillDto>> GetAllAsync(PaginationRequest request, SkillSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<SkillDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateSkillRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}