using LearningManagement.Occupation.Application.AbilityTypes.Contracts;
using LearningManagement.Occupation.Application.AbilityTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.AbilityTypes;

namespace LearningManagement.Occupation.Infrastructure.AbilityTypes.Repositories;

public class AbilityTypeRepository(ApplicationDbContext context)
    : EfGenericRepository<AbilityType>(context: context), IAbilityTypeRepository {
    public Task<PaginatedResult<AbilityType>> GetAllAsync(bool asNoTracking, PaginationRequest request, AbilityTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.Abilities);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<AbilityType> AddSearchQueries(AbilityTypeSearchRequest searchRequest, IQueryable<AbilityType> query) {
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