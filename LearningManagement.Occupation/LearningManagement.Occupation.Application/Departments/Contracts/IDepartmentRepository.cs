using LearningManagement.Occupation.Domain.Departments.Models;

namespace LearningManagement.Occupation.Application.Departments.Contracts;

public interface IDepartmentRepository {
    Task<List<Department>> GetAllAsync(bool asNoTracking = true, CancellationToken cancellationToken = default);
    Task<Department?> FindByIdAsync(long id, bool asNoTracking = true, CancellationToken cancellationToken = default);
    void Add(Department department);
    void Update(Department product);
    void Remove(Department product);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(long id, CancellationToken cancellationToken = default);
}