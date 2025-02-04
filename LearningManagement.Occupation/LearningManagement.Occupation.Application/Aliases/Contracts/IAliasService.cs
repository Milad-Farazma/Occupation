using LearningManagement.Occupation.Application.Aliases.Dtos;
using LearningManagement.Occupation.Application.Aliases.Dtos.Create;
using LearningManagement.Occupation.Application.Aliases.Dtos.Get;

namespace LearningManagement.Occupation.Application.Aliases.Contracts;

public interface IAliasService {
    Task<CreateAliasResponse> CreateAsync(CreateAliasRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<AliasDto>> GetAllAsync(PaginationRequest request, AliasSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<AliasDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateAliasRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}