using LearningManagement.Occupation.Application.SkillTypes.Dtos;

namespace LearningManagement.Occupation.Application.SkillTypes.Contracts;

public interface ISkillTypeService {
    Task<CreateSkillTypeResponse> CreateAsync(CreateSkillTypeRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<SkillTypeDto>> GetAllAsync(PaginationRequest request, SkillTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<SkillTypeDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateSkillTypeRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}