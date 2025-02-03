using LearningManagement.Occupation.Application.Departments.Dtos.Get;
using LearningManagement.Occupation.Domain.Departments;

namespace LearningManagement.Occupation.Application.Departments.Contracts;

public interface IDepartmentRepository {
    Task<PaginatedResult<Department>> GetAllAsync(bool asNoTracking, PaginationRequest request, DepartmentSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<Department?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(Department entity);
    void Update(Department entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}