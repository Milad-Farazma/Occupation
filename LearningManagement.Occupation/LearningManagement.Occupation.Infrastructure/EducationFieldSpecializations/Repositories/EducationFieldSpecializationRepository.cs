using Framework.Pagination;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;
using LearningManagement.Occupation.Domain.EducationFieldSpecializations;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.Infrastructure.EducationFieldSpecializations.Repositories;

public class EducationFieldSpecializationRepository(ApplicationDbContext context)
    : EfGenericRepository<EducationFieldSpecialization>(context: context), IEducationFieldSpecializationRepository {
    public Task<PaginatedResult<EducationFieldSpecialization>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        EducationFieldSpecializationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query.ApplyPagination(request, cancellationToken: cancellationToken);
    }

    public Task<PaginatedResult<EducationFieldSpecialization>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        EducationFieldSpecializationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        return query.Include(item => item.EducationField)
            .ApplyPagination(request, cancellationToken: cancellationToken);
    }

    private static IQueryable<EducationFieldSpecialization> AddSearchQueries(EducationFieldSpecializationSearchRequest searchRequest,
        IQueryable<EducationFieldSpecialization> query) {
        if (searchRequest.Title is not null) {
            query = query.Where(item => item.Title!.Contains(searchRequest.Title));
        }

        if (searchRequest.Code is not null) {
            query = query.Where(item => item.Code == searchRequest.Code);
        }

        if (searchRequest.Description is not null) {
            query = query.Where(item => item.Description!.Contains(searchRequest.Description));
        }

        return query;
    }
}