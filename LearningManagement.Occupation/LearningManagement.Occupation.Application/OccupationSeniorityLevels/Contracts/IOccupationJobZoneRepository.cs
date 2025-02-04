using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos.Get;
using LearningManagement.Occupation.Domain.Occupations;

namespace LearningManagement.Occupation.Application.OccupationSeniorityLevels.Contracts;

public interface IOccupationSeniorityLevelRepository {
    Task<PaginatedResult<OccupationSeniorityLevel>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        OccupationSeniorityLevelSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<OccupationSeniorityLevel?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(OccupationSeniorityLevel entity);
    void Update(OccupationSeniorityLevel entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}