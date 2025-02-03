using LearningManagement.Occupation.Application.Technologys.Dtos;
using LearningManagement.Occupation.Application.Technologys.Dtos.Create;
using LearningManagement.Occupation.Application.Technologys.Dtos.Get;

namespace LearningManagement.Occupation.Application.Technologys.Contracts;

public interface ITechnologyService {
    Task<CreateTechnologyResponse> CreateAsync(CreateTechnologyRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<TechnologyDto>> GetAllAsync(PaginationRequest request, TechnologySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<TechnologyDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateTechnologyRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}