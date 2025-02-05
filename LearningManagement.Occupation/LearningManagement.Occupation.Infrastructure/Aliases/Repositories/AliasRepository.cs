using LearningManagement.Occupation.Application.Aliases.Contracts;
using LearningManagement.Occupation.Application.Aliases.Dtos.Get;
using LearningManagement.Occupation.Domain.Aliases;

namespace LearningManagement.Occupation.Infrastructure.Aliases.Repositories;

public class AliasRepository(ApplicationDbContext context)
    : EfGenericRepository<Alias>(context: context), IAliasRepository {
    public Task<PaginatedResult<Alias>> GetAllAsync(bool asNoTracking, PaginationRequest request, AliasSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Alias> AddSearchQueries(AliasSearchRequest searchRequest, IQueryable<Alias> query) {
        if (!string.IsNullOrWhiteSpace(searchRequest.AlternativeTitle)) {
            query = query.Where(item => item.AlternativeTitle.Contains(searchRequest.AlternativeTitle));
        }

        if (searchRequest.OccupationId is not null) {
            query = query.Where(item => item.OccupationId == searchRequest.OccupationId);
        }

        return query;
    }
}