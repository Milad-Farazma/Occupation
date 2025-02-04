using LearningManagement.Occupation.Application.OccupationSimilarities.Contracts;
using LearningManagement.Occupation.Application.OccupationSimilarities.Dtos.Get;
using LearningManagement.Occupation.Domain.OccupationSimilarities;

namespace LearningManagement.Occupation.Infrastructure.OccupationSimilarities.Repositories;

public class OccupationSimilarityRepository(ApplicationDbContext context)
    : EfGenericRepository<OccupationSimilarity>(context: context), IOccupationSimilarityRepository {
    public Task<PaginatedResult<OccupationSimilarity>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        OccupationSimilaritySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        // if (loadRelations) {
        //     query = query.Include(item => item.OccupationSimilarityType);
        // }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<OccupationSimilarity> AddSearchQueries(OccupationSimilaritySearchRequest searchRequest,
        IQueryable<OccupationSimilarity> query) {
        if (!string.IsNullOrWhiteSpace(searchRequest.Description)) {
            query = query.Where(item => item.Description!.Contains(searchRequest.Description));
        }

        return query;
    }
}