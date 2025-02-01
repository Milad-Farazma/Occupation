using LearningManagement.Occupation.Application.InterestTypes.Contracts;
using LearningManagement.Occupation.Application.InterestTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.InterestTypes;

namespace LearningManagement.Occupation.Infrastructure.InterestTypes.Repositories;

public class InterestTypeRepository(ApplicationDbContext context)
    : EfGenericRepository<InterestType>(context: context), IInterestTypeRepository {
    public Task<PaginatedResult<InterestType>> GetAllAsync(bool asNoTracking, PaginationRequest request, InterestTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.Interests);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<InterestType> AddSearchQueries(InterestTypeSearchRequest searchRequest, IQueryable<InterestType> query) {
        if (!string.IsNullOrWhiteSpace(searchRequest.Title)) {
            query = query.Where(item => item.Title.Contains(searchRequest.Title));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.Description)) {
            query = query.Where(item => item.Description!.Contains(searchRequest.Description));
        }

        return query;
    }
}