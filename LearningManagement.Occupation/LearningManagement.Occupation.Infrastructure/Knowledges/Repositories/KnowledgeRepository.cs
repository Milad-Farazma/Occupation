using LearningManagement.Occupation.Application.Knowledges.Contracts;
using LearningManagement.Occupation.Application.Knowledges.Dtos.Get;
using LearningManagement.Occupation.Domain.Knowledges;

namespace LearningManagement.Occupation.Infrastructure.Knowledges.Repositories;

public class KnowledgeRepository(ApplicationDbContext context)
    : EfGenericRepository<Knowledge>(context: context), IKnowledgeRepository {
    public Task<PaginatedResult<Knowledge>> GetAllAsync(bool asNoTracking, PaginationRequest request, KnowledgeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.KnowledgeType);
        }

        return query
            .OrderBy(item => item.Id)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<Knowledge> AddSearchQueries(KnowledgeSearchRequest searchRequest, IQueryable<Knowledge> query) {
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