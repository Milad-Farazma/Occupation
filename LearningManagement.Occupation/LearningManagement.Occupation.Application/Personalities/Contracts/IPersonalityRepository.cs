using LearningManagement.Occupation.Application.Personalities.Dtos;
using LearningManagement.Occupation.Domain.Personalities;

namespace LearningManagement.Occupation.Application.Personalities.Contracts;

public interface IPersonalityRepository {
    Task<PaginatedResult<Personality>> GetAllAsync(bool asNoTracking, PaginationRequest request, PersonalitySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<Personality?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(Personality entity);
    void Update(Personality entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}