using LearningManagement.Occupation.Application.Abilities.Contracts;
using LearningManagement.Occupation.Application.Abilities.Dtos.Get;
using LearningManagement.Occupation.Domain.Abilities;

namespace LearningManagement.Occupation.Infrastructure.Abilitys.Repositories;

public class AbilityRepository(ApplicationDbContext context)
    : EfGenericRepository<Ability>(context: context), IAbilityRepository {
    public Task<PaginatedResult<Ability>> GetAllAsync(bool asNoTracking, PaginationRequest request, AbilitySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.AbilityType);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Ability> AddSearchQueries(AbilitySearchRequest searchRequest, IQueryable<Ability> query) {
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