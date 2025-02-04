using LearningManagement.Occupation.Application.JobPositions.Contracts;
using LearningManagement.Occupation.Application.JobPositions.Dtos;
using LearningManagement.Occupation.Application.JobPositions.Dtos.Get;
using LearningManagement.Occupation.Domain.JobPositions;

namespace LearningManagement.Occupation.Infrastructure.JobPositions.Repositories;

public class JobPositionRepository(ApplicationDbContext context)
    : EfGenericRepository<JobPosition>(context: context), IJobPositionRepository {
    public Task<PaginatedResult<JobPosition>> GetAllAsync(bool asNoTracking, PaginationRequest request, JobPositionSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.Occupation);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<JobPosition> AddSearchQueries(JobPositionSearchRequest searchRequest, IQueryable<JobPosition> query) {
        if (!string.IsNullOrWhiteSpace(searchRequest.Title)) {
            query = query.Where(item => item.Title!.Contains(searchRequest.Title));
        }

        if (searchRequest.ParentId is not null) {
            query = query.Where(item => item.ParentId == searchRequest.ParentId);
        }

        if (searchRequest.Capacity is not null) {
            query = query.Where(item => item.Capacity == searchRequest.Capacity);
        }

        return query;
    }
}