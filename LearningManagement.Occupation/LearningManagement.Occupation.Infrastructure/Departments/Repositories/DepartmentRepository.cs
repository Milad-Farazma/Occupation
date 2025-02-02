using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Dtos.Get;
using LearningManagement.Occupation.Domain.Departments;

namespace LearningManagement.Occupation.Infrastructure.Departments.Repositories;

public class DepartmentRepository(ApplicationDbContext context)
    : EfGenericRepository<Department>(context: context), IDepartmentRepository {
    public Task<PaginatedResult<Department>> GetAllAsync(bool asNoTracking, PaginationRequest request, DepartmentSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.DepartmentType);
            query = query.Include(item => item.Organization);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Department> AddSearchQueries(DepartmentSearchRequest searchRequest, IQueryable<Department> query) {
        if (!string.IsNullOrWhiteSpace(searchRequest.Title)) {
            query = query.Where(item => item.Title!.Contains(searchRequest.Title));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.Description)) {
            query = query.Where(item => item.Description!.Contains(searchRequest.Description));
        }

        if (searchRequest.Code is not null) {
            query = query.Where(item => item.Code == searchRequest.Code);
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.Address)) {
            query = query.Where(item => item.Address!.Contains(searchRequest.Address));
        }

        if (searchRequest.Phone is not null) {
            query = query.Where(item => item.Phone == searchRequest.Phone);
        }

        if (searchRequest.Fax is not null) {
            query = query.Where(item => item.Fax == searchRequest.Fax);
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.WebSiteUrl)) {
            query = query.Where(item => item.WebSiteUrl!.Contains(searchRequest.WebSiteUrl));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.Email)) {
            query = query.Where(item => item.Email!.Contains(searchRequest.Email));
        }

        return query;
    }
}