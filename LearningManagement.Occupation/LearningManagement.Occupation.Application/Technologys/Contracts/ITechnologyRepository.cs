using LearningManagement.Occupation.Application.Technologys.Dtos.Get;
using LearningManagement.Occupation.Domain.Technologys;

namespace LearningManagement.Occupation.Application.Technologys.Contracts;

public interface ITechnologyRepository {
    Task<PaginatedResult<Technology>> GetAllAsync(bool asNoTracking, PaginationRequest request, TechnologySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<Technology?> GetByIdAsync(long id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(Technology entity);
    void Update(Technology entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}