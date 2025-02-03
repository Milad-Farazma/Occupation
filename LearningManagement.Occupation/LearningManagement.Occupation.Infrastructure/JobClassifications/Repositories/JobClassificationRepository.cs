using LearningManagement.Occupation.Application.JobClassifications.Contracts;
using LearningManagement.Occupation.Application.JobClassifications.Dtos.Get;
using LearningManagement.Occupation.Domain.JobClassifications;

namespace LearningManagement.Occupation.Infrastructure.JobClassifications.Repositories;

public class JobClassificationRepository(ApplicationDbContext context)
    : EfGenericRepository<JobClassification>(context: context), IJobClassificationRepository {
    public Task<PaginatedResult<JobClassification>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        JobClassificationSearchRequest? searchRequest,
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

    private static IQueryable<JobClassification> AddSearchQueries(JobClassificationSearchRequest searchRequest, IQueryable<JobClassification> query) {
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