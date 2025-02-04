using LearningManagement.Occupation.Application.SeniorityLevels.Contracts;
using LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Get;
using LearningManagement.Occupation.Domain.SeniorityLevels;

namespace LearningManagement.Occupation.Infrastructure.SeniorityLevels.Repositories;

public class SeniorityLevelRepository(ApplicationDbContext context)
    : EfGenericRepository<SeniorityLevel>(context: context), ISeniorityLevelRepository {
    public Task<PaginatedResult<SeniorityLevel>> GetAllAsync(bool asNoTracking, PaginationRequest request, SeniorityLevelSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.OccupationSeniorityLevels);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<SeniorityLevel> AddSearchQueries(SeniorityLevelSearchRequest searchRequest, IQueryable<SeniorityLevel> query) {
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