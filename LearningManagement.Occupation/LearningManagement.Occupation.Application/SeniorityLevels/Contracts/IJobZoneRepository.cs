using LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Get;
using LearningManagement.Occupation.Domain.SeniorityLevels;

namespace LearningManagement.Occupation.Application.SeniorityLevels.Contracts;

public interface ISeniorityLevelRepository {
    Task<PaginatedResult<SeniorityLevel>> GetAllAsync(bool asNoTracking, PaginationRequest request, SeniorityLevelSearchRequest? searchRequest,
        bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<SeniorityLevel?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(SeniorityLevel entity);
    void Update(SeniorityLevel entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}