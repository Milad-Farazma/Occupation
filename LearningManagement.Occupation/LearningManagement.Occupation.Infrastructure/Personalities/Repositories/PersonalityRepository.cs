using LearningManagement.Occupation.Application.Personalities.Contracts;
using LearningManagement.Occupation.Application.Personalities.Dtos;
using LearningManagement.Occupation.Domain.Personalities;

namespace LearningManagement.Occupation.Infrastructure.Personalities.Repositories;

public class PersonalityRepository(ApplicationDbContext context)
    : EfGenericRepository<Personality>(context: context), IPersonalityRepository {
    public Task<PaginatedResult<Personality>> GetAllAsync(bool asNoTracking, PaginationRequest request, PersonalitySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Personality> AddSearchQueries(PersonalitySearchRequest searchRequest, IQueryable<Personality> query) {
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