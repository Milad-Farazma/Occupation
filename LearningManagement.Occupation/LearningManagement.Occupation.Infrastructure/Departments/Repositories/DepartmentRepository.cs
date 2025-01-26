using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Dtos;
using LearningManagement.Occupation.Domain.Departments;

namespace LearningManagement.Occupation.Infrastructure.Departments.Repositories;

public class DepartmentRepository(ApplicationDbContext context)
    : EfGenericRepository<Department>(context: context), IDepartmentRepository {
    public Task<PaginatedResult<Department>> GetAllAsync(bool asNoTracking, PaginationRequest request, DepartmentSearchRequest? searchRequest,
        bool loadRelations,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.Organization);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Department> AddSearchQueries(DepartmentSearchRequest searchRequest, IQueryable<Department> query) {
        if (!string.IsNullOrWhiteSpace(searchRequest.Title)) {
            query = query.Where(item => item.Title.Contains(searchRequest.Title));
        }

        return query;
    }
}