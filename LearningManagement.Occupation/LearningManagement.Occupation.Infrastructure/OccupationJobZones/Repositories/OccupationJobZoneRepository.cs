using LearningManagement.Occupation.Application.OccupationJobZones.Contracts;
using LearningManagement.Occupation.Application.OccupationJobZones.Dtos.Get;
using LearningManagement.Occupation.Domain.OccupationJobZones;

namespace LearningManagement.Occupation.Infrastructure.OccupationJobZones.Repositories;

public class OccupationJobZoneRepository(ApplicationDbContext context)
    : EfGenericRepository<OccupationJobZone>(context: context), IOccupationJobZoneRepository {
    public Task<PaginatedResult<OccupationJobZone>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        OccupationJobZoneSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.JobZone)
                .Include(item => item.Occupation);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<OccupationJobZone> AddSearchQueries(OccupationJobZoneSearchRequest searchRequest, IQueryable<OccupationJobZone> query) {
        if (!string.IsNullOrWhiteSpace(searchRequest.Description)) {
            query = query.Where(item => item.Description!.Contains(searchRequest.Description));
        }

        return query;
    }
}