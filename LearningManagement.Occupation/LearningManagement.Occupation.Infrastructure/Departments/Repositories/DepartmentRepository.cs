using Framework.Pagination;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Domain.Departments.Models;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.Infrastructure.Departments.Repositories;

public class DepartmentRepository(ApplicationDbContext context) : EfGenericRepository<Department>(context: context), IDepartmentRepository {
    public Task<PaginatedResult<Department>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request, CancellationToken cancellationToken = default) {
        return GetDbSet(asNoTracking)
            .Include(d => d.Organization)
            .OrderBy(e=> e.Id)
            .ApplyPagination(request, cancellationToken);
    }
}