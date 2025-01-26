using LearningManagement.Occupation.Application.EducationFields.Dtos.Get;
using LearningManagement.Occupation.Domain.EducationFields;

namespace LearningManagement.Occupation.Application.EducationFields.Contracts;

public interface IEducationFieldRepository {
    Task<PaginatedResult<EducationField>> GetAllAsync(bool asNoTracking, PaginationRequest request, EducationFieldSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<EducationField?> GetByIdAsync(long id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(EducationField entity);
    void Update(EducationField entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}