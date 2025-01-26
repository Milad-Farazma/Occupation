using Framework.Pagination;
using LearningManagement.Occupation.Application.EducationFields.Contracts;
using LearningManagement.Occupation.Application.EducationFields.Dtos.Get;
using LearningManagement.Occupation.Domain.EducationFields;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.Infrastructure.EducationFields.Repositories;

public class EducationFieldRepository(ApplicationDbContext context)
    : EfGenericRepository<EducationField>(context: context), IEducationFieldRepository {
    public Task<PaginatedResult<EducationField>> GetAllAsync(bool asNoTracking, PaginationRequest request, EducationFieldSearchRequest? searchRequest,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query.ApplyPagination(request, cancellationToken: cancellationToken);
    }

    public Task<PaginatedResult<EducationField>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        EducationFieldSearchRequest? searchRequest,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query.Include(item => item.EducationFieldSpecializations)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<EducationField> AddSearchQueries(EducationFieldSearchRequest searchRequest, IQueryable<EducationField> query) {
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