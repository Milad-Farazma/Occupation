using LearningManagement.Occupation.Application.Skills.Contracts;
using LearningManagement.Occupation.Application.Skills.Dtos;
using LearningManagement.Occupation.Domain.Skills;

namespace LearningManagement.Occupation.Infrastructure.Skills.Repositories;

public class SkillRepository(ApplicationDbContext context)
    : EfGenericRepository<Skill>(context: context), ISkillRepository {
    public Task<PaginatedResult<Skill>> GetAllAsync(bool asNoTracking, PaginationRequest request, SkillSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.SkillType);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Skill> AddSearchQueries(SkillSearchRequest searchRequest, IQueryable<Skill> query) {
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