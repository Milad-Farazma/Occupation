using LearningManagement.Occupation.Domain.Departments.Models;

namespace LearningManagement.Occupation.Application.Departments.Contracts;

public interface IDepartmentRepository {
    Task<PaginatedResult<Department>> GetAllAsync(bool asNoTracking, PaginationRequest request, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<Department?> GetByIdAsync(long id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(Department entity);
    void Update(Department entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}