using LearningManagement.Occupation.Application.TechnologyTypes.Contracts;
using LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.TechnologyTypes;

namespace LearningManagement.Occupation.Infrastructure.TechnologyTypes.Repositories;

public class TechnologyTypeRepository(ApplicationDbContext context)
    : EfGenericRepository<TechnologyType>(context: context), ITechnologyTypeRepository {
    public Task<PaginatedResult<TechnologyType>> GetAllAsync(bool asNoTracking, PaginationRequest request, TechnologyTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.Technologies);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<TechnologyType> AddSearchQueries(TechnologyTypeSearchRequest searchRequest, IQueryable<TechnologyType> query) {
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