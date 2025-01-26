using LearningManagement.Occupation.Application.EducationFields.Dtos.Get;
using LearningManagement.Occupation.Domain.EducationFields;

namespace LearningManagement.Occupation.Application.EducationFields.Contracts;

public interface IEducationFieldRepository {
    Task<PaginatedResult<EducationField>> GetAllAsync(bool asNoTracking, PaginationRequest request, EducationFieldSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);

    Task<PaginatedResult<EducationField>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        EducationFieldSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);

    Task<EducationField?> GetByIdAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    Task<EducationField?> GetByIdWithRelationsAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    void Add(EducationField entity);
    void Update(EducationField entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}