using LearningManagement.Occupation.Application.EducationDegrees.Dtos;
using LearningManagement.Occupation.Domain.EducationDegrees;

namespace LearningManagement.Occupation.Application.EducationDegrees.Contracts;

public interface IEducationDegreeRepository {
    Task<PaginatedResult<EducationDegree>> GetAllAsync(bool asNoTracking, PaginationRequest request, EducationDegreeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<EducationDegree?> GetByIdAsync(long id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(EducationDegree entity);
    void Update(EducationDegree entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}