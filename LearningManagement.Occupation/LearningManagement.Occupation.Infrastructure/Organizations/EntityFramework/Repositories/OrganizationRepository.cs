using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Application.Organizations.Dto.Get;
using LearningManagement.Occupation.Domain.Organizations.Models;

namespace LearningManagement.Occupation.Infrastructure.Organizations.EntityFramework.Repositories;

public class OrganizationRepository(ApplicationDbContext context) : EfGenericRepository<Organization>(context: context), IOrganizationRepository {
    public Task<PaginatedResult<Organization>> GetAllAsync(bool asNoTracking, PaginationRequest request, OrganizationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query.ApplyPagination(request, cancellationToken: cancellationToken);
    }

    public Task<PaginatedResult<Organization>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        OrganizationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query.Include(item => item.OrganizationType)
            .Include(item => item.Departments)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Organization> AddSearchQueries(OrganizationSearchRequest searchRequest, IQueryable<Organization> query) {
        if (!string.IsNullOrWhiteSpace(searchRequest.Title)) {
            query = query.Where(x => x.Title!.Contains(searchRequest.Title));
        }

        if (searchRequest.Code.HasValue) {
            query = query.Where(x => x.Code == searchRequest.Code);
        }

        if (searchRequest.ProvinceId.HasValue) {
            query = query.Where(x => x.ProvinceId == searchRequest.ProvinceId);
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.ProvinceTitle)) {
            query = query.Where(x => x.ProvinceTitle.Contains(searchRequest.ProvinceTitle));
        }

        if (searchRequest.CityId.HasValue) {
            query = query.Where(x => x.CityId == searchRequest.CityId);
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.CityTitle)) {
            query = query.Where(x => x.CityTitle.Contains(searchRequest.CityTitle));
        }

        if (searchRequest.OrganizationTypeId.HasValue) {
            query = query.Where(x => x.OrganizationTypeId == searchRequest.OrganizationTypeId);
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.CertificateCode)) {
            query = query.Where(x => x.CertificateCode!.Contains(searchRequest.CertificateCode));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.WebsiteUrl)) {
            query = query.Where(x => x.WebsiteUrl!.Contains(searchRequest.WebsiteUrl));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.Email)) {
            query = query.Where(x => x.Email!.Contains(searchRequest.Email));
        }

        if (searchRequest.Accepted.HasValue) {
            query = query.Where(x => x.Accepted == searchRequest.Accepted);
        }

        if (searchRequest.AcceptedDate.HasValue) {
            query = query.Where(x => x.AcceptedDate == searchRequest.AcceptedDate);
        }

        if (searchRequest.IsPublic.HasValue) {
            query = query.Where(x => x.IsPublic == searchRequest.IsPublic);
        }

        return query;
    }
}