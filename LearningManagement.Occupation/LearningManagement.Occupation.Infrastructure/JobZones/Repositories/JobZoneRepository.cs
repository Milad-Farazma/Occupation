using LearningManagement.Occupation.Application.JobZones.Contracts;
using LearningManagement.Occupation.Application.JobZones.Dtos.Get;
using LearningManagement.Occupation.Domain.JobZones;

namespace LearningManagement.Occupation.Infrastructure.JobZones.Repositories;

public class JobZoneRepository(ApplicationDbContext context)
    : EfGenericRepository<JobZone>(context: context), IJobZoneRepository {
    public Task<PaginatedResult<JobZone>> GetAllAsync(bool asNoTracking, PaginationRequest request, JobZoneSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.OccupationJobZons);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<JobZone> AddSearchQueries(JobZoneSearchRequest searchRequest, IQueryable<JobZone> query) {
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