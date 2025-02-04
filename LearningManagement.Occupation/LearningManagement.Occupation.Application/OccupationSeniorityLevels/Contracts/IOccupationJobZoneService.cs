using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos;
using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos.Create;
using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos.Get;

namespace LearningManagement.Occupation.Application.OccupationSeniorityLevels.Contracts;

public interface IOccupationSeniorityLevelService {
    Task<CreateOccupationSeniorityLevelResponse> CreateAsync(CreateOccupationSeniorityLevelRequest request,
        CancellationToken cancellationToken = default);

    Task<PaginatedResult<OccupationSeniorityLevelDto>> GetAllAsync(PaginationRequest request, OccupationSeniorityLevelSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<OccupationSeniorityLevelDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateOccupationSeniorityLevelRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}