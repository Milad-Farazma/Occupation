using LearningManagement.Occupation.Application.JobOutLooks.Contracts;
using LearningManagement.Occupation.Application.JobOutLooks.Dtos.Get;
using LearningManagement.Occupation.Domain.JobOutLooks;

namespace LearningManagement.Occupation.Infrastructure.JobOutLooks.Repositories;

public class JobOutLookRepository(ApplicationDbContext context)
    : EfGenericRepository<JobOutLook>(context: context), IJobOutLookRepository {
    public Task<PaginatedResult<JobOutLook>> GetAllAsync(bool asNoTracking, PaginationRequest request, JobOutLookSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.Occupations);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<JobOutLook> AddSearchQueries(JobOutLookSearchRequest searchRequest, IQueryable<JobOutLook> query) {
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