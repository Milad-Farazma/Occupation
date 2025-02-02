using LearningManagement.Occupation.Application.KnowledgeTypes.Contracts;
using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.KnowledgeTypes;

namespace LearningManagement.Occupation.Infrastructure.KnowledgeTypes.Repositories;

public class KnowledgeTypeRepository(ApplicationDbContext context)
    : EfGenericRepository<KnowledgeType>(context: context), IKnowledgeTypeRepository {
    public Task<PaginatedResult<KnowledgeType>> GetAllAsync(bool asNoTracking, PaginationRequest request, KnowledgeTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.Knowledges);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<KnowledgeType> AddSearchQueries(KnowledgeTypeSearchRequest searchRequest, IQueryable<KnowledgeType> query) {
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