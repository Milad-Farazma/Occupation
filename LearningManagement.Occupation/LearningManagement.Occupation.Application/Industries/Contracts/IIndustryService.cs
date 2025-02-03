using LearningManagement.Occupation.Application.Industries.Dtos;

namespace LearningManagement.Occupation.Application.Industries.Contracts;

public interface IIndustryService {
    Task<CreateIndustryResponse> CreateAsync(CreateIndustryRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<IndustryDto>> GetAllAsync(PaginationRequest request, IndustrySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<IndustryDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateIndustryRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}