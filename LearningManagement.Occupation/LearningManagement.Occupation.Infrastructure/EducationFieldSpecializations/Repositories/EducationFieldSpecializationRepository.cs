using LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Get;
using LearningManagement.Occupation.Domain.EducationFieldSpecializations;

namespace LearningManagement.Occupation.Infrastructure.EducationFieldSpecializations.Repositories;

public class EducationFieldSpecializationRepository(ApplicationDbContext context)
    : EfGenericRepository<EducationFieldSpecialization>(context: context), IEducationFieldSpecializationRepository {
    public Task<PaginatedResult<EducationFieldSpecialization>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        EducationFieldSpecializationSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);
        if (searchRequest is not null) {
            query = AddSearchQueries(searchRequest, query);
        }

        if (loadRelations) {
            query = query.Include(item => item.EducationField);
        }

        return query.OrderBy(item => item.Id)
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