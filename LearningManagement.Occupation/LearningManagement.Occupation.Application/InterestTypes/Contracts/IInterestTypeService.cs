using LearningManagement.Occupation.Application.InterestTypes.Dtos;
using LearningManagement.Occupation.Application.InterestTypes.Dtos.Create;
using LearningManagement.Occupation.Application.InterestTypes.Dtos.Get;

namespace LearningManagement.Occupation.Application.InterestTypes.Contracts;

public interface IInterestTypeService {
    Task<CreateInterestTypeResponse> CreateAsync(CreateInterestTypeRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<InterestTypeDto>> GetAllAsync(PaginationRequest request, InterestTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<InterestTypeDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateInterestTypeRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}