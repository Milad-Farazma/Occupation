using LearningManagement.Occupation.Application.Occupations.Contracts;
using LearningManagement.Occupation.Application.Occupations.Dtos.Get;

namespace LearningManagement.Occupation.Infrastructure.Occupations.Repositories;

public class OccupationRepository(ApplicationDbContext context)
    : EfGenericRepository<Domain.Occupations.Occupation>(context: context), IOccupationRepository {
    public Task<PaginatedResult<Domain.Occupations.Occupation>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        OccupationSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.JobClassification)
                .Include(item => item.JobOutlook)
                .Include(item => item.OccupationSeniorityLevels);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Domain.Occupations.Occupation> AddSearchQueries(OccupationSearchRequest searchRequest,
        IQueryable<Domain.Occupations.Occupation> query) {
        if (!string.IsNullOrWhiteSpace(searchRequest.Title)) {
            query = query.Where(item => item.Title!.Contains(searchRequest.Title));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.Description)) {
            query = query.Where(item => item.Description!.Contains(searchRequest.Description));
        }

        if (searchRequest.Code is not null) {
            query = query.Where(item => item.Code == searchRequest.Code);
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.BriefActivities)) {
            query = query.Where(item => item.BriefActivities!.Contains(searchRequest.BriefActivities));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.IntroductionVideoUrl)) {
            query = query.Where(item => item.IntroductionVideoUrl!.Contains(searchRequest.IntroductionVideoUrl));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.BriefPersonality)) {
            query = query.Where(item => item.BriefPersonality!.Contains(searchRequest.BriefPersonality));
        }

        return query;
    }
}