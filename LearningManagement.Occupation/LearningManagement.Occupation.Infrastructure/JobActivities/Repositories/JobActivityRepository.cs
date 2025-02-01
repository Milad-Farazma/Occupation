using LearningManagement.Occupation.Application.JobActivities.Contracts;
using LearningManagement.Occupation.Application.JobActivities.Dtos;
using LearningManagement.Occupation.Domain.JobActivitys;

namespace LearningManagement.Occupation.Infrastructure.JobActivities.Repositories;

public class JobActivityRepository(ApplicationDbContext context)
    : EfGenericRepository<JobActivity>(context: context), IJobActivityRepository {
    public Task<PaginatedResult<JobActivity>> GetAllAsync(bool asNoTracking, PaginationRequest request, JobActivitySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<JobActivity> AddSearchQueries(JobActivitySearchRequest searchRequest, IQueryable<JobActivity> query) {
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