using LearningManagement.Occupation.Application.SkillTypes.Contracts;
using LearningManagement.Occupation.Application.SkillTypes.Dtos;
using LearningManagement.Occupation.Domain.SkillTypes;

namespace LearningManagement.Occupation.Infrastructure.SkillTypes.Repositories;

public class SkillTypeRepository(ApplicationDbContext context)
    : EfGenericRepository<SkillType>(context: context), ISkillTypeRepository {
    public Task<PaginatedResult<SkillType>> GetAllAsync(bool asNoTracking, PaginationRequest request, SkillTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.Skills);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<SkillType> AddSearchQueries(SkillTypeSearchRequest searchRequest, IQueryable<SkillType> query) {
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