using LearningManagement.Occupation.Application.Industries.Contracts;
using LearningManagement.Occupation.Application.Industries.Dtos;
using LearningManagement.Occupation.Domain.Industries;

namespace LearningManagement.Occupation.Infrastructure.Industries.Repositories;

public class IndustryRepository(ApplicationDbContext context)
    : EfGenericRepository<Industry>(context: context), IIndustryRepository {
    public Task<PaginatedResult<Industry>> GetAllAsync(bool asNoTracking, PaginationRequest request, IndustrySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Industry> AddSearchQueries(IndustrySearchRequest searchRequest, IQueryable<Industry> query) {
        if (!string.IsNullOrWhiteSpace(searchRequest.Title)) {
            query = query.Where(item => item.Title!.Contains(searchRequest.Title));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.Description)) {
            query = query.Where(item => item.Description!.Contains(searchRequest.Description));
        }

        if (searchRequest.Code is not null) {
            query = query.Where(item => item.Code == searchRequest.Code);
        }

        return query;
    }
}