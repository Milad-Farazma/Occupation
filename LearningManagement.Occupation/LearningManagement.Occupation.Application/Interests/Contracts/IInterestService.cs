using LearningManagement.Occupation.Application.Interests.Dtos;
using LearningManagement.Occupation.Application.Interests.Dtos.Create;
using LearningManagement.Occupation.Application.Interests.Dtos.Get;

namespace LearningManagement.Occupation.Application.Interests.Contracts;

public interface IInterestService {
    Task<CreateInterestResponse> CreateAsync(CreateInterestRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<InterestDto>> GetAllAsync(PaginationRequest request, InterestSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<InterestDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateInterestRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}