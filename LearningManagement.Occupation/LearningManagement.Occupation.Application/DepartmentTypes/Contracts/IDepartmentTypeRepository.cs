using LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.DepartmentTypes;

namespace LearningManagement.Occupation.Application.DepartmentTypes.Contracts;

public interface IDepartmentTypeRepository {
    Task<PaginatedResult<DepartmentType>> GetAllAsync(bool asNoTracking, PaginationRequest request, DepartmentTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<DepartmentType?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(DepartmentType entity);
    void Update(DepartmentType entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}