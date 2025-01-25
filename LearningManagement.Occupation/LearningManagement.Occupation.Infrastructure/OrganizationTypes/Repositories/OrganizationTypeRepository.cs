using Framework.Pagination;
using LearningManagement.Occupation.Application.OrganizationTypes.Contracts;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.OrganizationTypes;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.Infrastructure.OrganizationTypes.Repositories;

public class OrganizationTypeRepository(ApplicationDbContext context)
    : EfGenericRepository<OrganizationType>(context: context), IOrganizationTypeRepository {
    public Task<PaginatedResult<OrganizationType>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        OrganizationTypeSearchRequest? searchRequest,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query.ApplyPagination(request, cancellationToken: cancellationToken);
    }

    public Task<PaginatedResult<OrganizationType>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        OrganizationTypeSearchRequest? searchRequest,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        query = query.Include(item => item.Organizations);
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