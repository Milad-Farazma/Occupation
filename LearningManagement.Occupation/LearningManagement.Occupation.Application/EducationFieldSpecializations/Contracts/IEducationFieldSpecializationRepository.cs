using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Get;
using LearningManagement.Occupation.Domain.EducationFieldSpecializations;

namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;

public interface IEducationFieldSpecializationRepository {
    Task<PaginatedResult<EducationFieldSpecialization>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        EducationFieldSpecializationSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<EducationFieldSpecialization?> GetByIdAsync(long id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(EducationFieldSpecialization entity);
    void Update(EducationFieldSpecialization entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}