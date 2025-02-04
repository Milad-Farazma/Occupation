using LearningManagement.Occupation.Application.SeniorityLevels.Dtos;
using LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Create;
using LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Get;

namespace LearningManagement.Occupation.Application.SeniorityLevels.Contracts;

public interface ISeniorityLevelService {
    Task<CreateSeniorityLevelResponse> CreateAsync(CreateSeniorityLevelRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<SeniorityLevelDto>> GetAllAsync(PaginationRequest request, SeniorityLevelSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<SeniorityLevelDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateSeniorityLevelRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}