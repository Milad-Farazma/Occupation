using LearningManagement.Occupation.Application.Interests.Contracts;
using LearningManagement.Occupation.Application.Interests.Dtos.Get;
using LearningManagement.Occupation.Domain.Interests;

namespace LearningManagement.Occupation.Infrastructure.Interests.Repositories;

public class InterestRepository(ApplicationDbContext context)
    : EfGenericRepository<Interest>(context: context), IInterestRepository {
    public Task<PaginatedResult<Interest>> GetAllAsync(bool asNoTracking, PaginationRequest request, InterestSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.InterestType);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Interest> AddSearchQueries(InterestSearchRequest searchRequest, IQueryable<Interest> query) {
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