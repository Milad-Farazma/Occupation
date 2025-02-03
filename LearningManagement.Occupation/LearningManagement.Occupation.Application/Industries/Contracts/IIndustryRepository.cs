using LearningManagement.Occupation.Application.Industries.Dtos;
using LearningManagement.Occupation.Domain.Industries;

namespace LearningManagement.Occupation.Application.Industries.Contracts;

public interface IIndustryRepository {
    Task<PaginatedResult<Industry>> GetAllAsync(bool asNoTracking, PaginationRequest request, IndustrySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<Industry?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(Industry entity);
    void Update(Industry entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}