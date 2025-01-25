using Framework.Pagination;
using LearningManagement.Occupation.Application.Shared;
using LearningManagement.Occupation.Domain.Departments.Models;

namespace LearningManagement.Occupation.Application.Departments.Contracts;

public interface IDepartmentRepository {
    Task<PaginatedResult<Department>> GetAllAsync(bool asNoTracking, PaginationRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<Department>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        CancellationToken cancellationToken = default);

    Task<Department?> GetByIdAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    Task<Department?> GetByIdWithRelationsAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    void Add(Department entity);
    void Update(Department entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}