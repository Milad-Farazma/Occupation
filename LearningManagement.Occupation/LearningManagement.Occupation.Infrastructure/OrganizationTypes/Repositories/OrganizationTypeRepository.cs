using LearningManagement.Occupation.Application.OrganizationTypes.Contracts;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.OrganizationTypes;

namespace LearningManagement.Occupation.Infrastructure.OrganizationTypes.Repositories;

public class OrganizationTypeRepository(ApplicationDbContext context)
    : EfGenericRepository<OrganizationType>(context: context), IOrganizationTypeRepository {
    public Task<PaginatedResult<OrganizationType>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        OrganizationTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.Organizations);
        }

        return query.ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<OrganizationType> AddSearchQueries(OrganizationTypeSearchRequest searchRequest, IQueryable<OrganizationType> query) {
        if (searchRequest.Title != null) {
            query = query.Where(x => x.Title!.Contains(searchRequest.Title));
        }

        if (searchRequest.Code != null) {
            query = query.Where(x => x.Code == searchRequest.Code);
        }

        if (searchRequest.Description != null) {
            query = query.Where(x => x.Description!.Contains(searchRequest.Description));
        }

        return query;
    }
}