using Framework.Pagination;
using LearningManagement.Occupation.Application.Shared;
using LearningManagement.Occupation.Domain.Departments.Models;

namespace LearningManagement.Occupation.Application.Departments.Contracts;

public interface IDepartmentRepository : IGenericRepository<Department> {
    Task<PaginatedResult<Department>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request, CancellationToken cancellationToken = default);
}