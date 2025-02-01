using LearningManagement.Occupation.Application.EducationDegrees.Contracts;
using LearningManagement.Occupation.Application.EducationDegrees.Dtos;
using LearningManagement.Occupation.Domain.EducationDegrees;

namespace LearningManagement.Occupation.Infrastructure.EducationDegrees.Repositories;

public class EducationDegreeRepository(ApplicationDbContext context)
    : EfGenericRepository<EducationDegree>(context: context), IEducationDegreeRepository {
    public Task<PaginatedResult<EducationDegree>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        EducationDegreeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<EducationDegree> AddSearchQueries(EducationDegreeSearchRequest searchRequest, IQueryable<EducationDegree> query) {
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