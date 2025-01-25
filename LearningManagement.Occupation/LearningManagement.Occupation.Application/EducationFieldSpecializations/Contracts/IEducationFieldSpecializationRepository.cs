using Framework.Pagination;
using LearningManagement.Occupation.Application.EducationFields.Dtos;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos;
using LearningManagement.Occupation.Domain.EducationFieldSpecializations;

namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;

public interface IEducationFieldSpecializationRepository {
    Task<PaginatedResult<EducationFieldSpecialization>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        EducationFieldSpecializationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);

    Task<PaginatedResult<EducationFieldSpecialization>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        EducationFieldSpecializationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);

    Task<EducationFieldSpecialization?> GetByIdAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    Task<EducationFieldSpecialization?> GetByIdWithRelationsAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    void Add(EducationFieldSpecialization entity);
    void Update(EducationFieldSpecialization entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}