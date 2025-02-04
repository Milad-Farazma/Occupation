using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Contracts;
using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos.Get;
using LearningManagement.Occupation.Domain.Occupations;

namespace LearningManagement.Occupation.Infrastructure.OccupationSeniorityLevels.Repositories;

public class OccupationSeniorityLevelRepository(ApplicationDbContext context)
    : EfGenericRepository<OccupationSeniorityLevel>(context: context), IOccupationSeniorityLevelRepository {
    public Task<PaginatedResult<OccupationSeniorityLevel>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        OccupationSeniorityLevelSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.SeniorityLevel)
                .Include(item => item.Occupation);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<OccupationSeniorityLevel> AddSearchQueries(OccupationSeniorityLevelSearchRequest searchRequest,
        IQueryable<OccupationSeniorityLevel> query) {
        if (!string.IsNullOrWhiteSpace(searchRequest.Description)) {
            query = query.Where(item => item.Description!.Contains(searchRequest.Description));
        }

        return query;
    }
}