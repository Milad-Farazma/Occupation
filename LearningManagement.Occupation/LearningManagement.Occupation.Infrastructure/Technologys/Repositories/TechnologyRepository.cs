using LearningManagement.Occupation.Application.Technologys.Contracts;
using LearningManagement.Occupation.Application.Technologys.Dtos.Get;
using LearningManagement.Occupation.Domain.Technologys;

namespace LearningManagement.Occupation.Infrastructure.Technologys.Repositories;

public class TechnologyRepository(ApplicationDbContext context)
    : EfGenericRepository<Technology>(context: context), ITechnologyRepository {
    public Task<PaginatedResult<Technology>> GetAllAsync(bool asNoTracking, PaginationRequest request, TechnologySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.TechnologyType);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Technology> AddSearchQueries(TechnologySearchRequest searchRequest, IQueryable<Technology> query) {
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