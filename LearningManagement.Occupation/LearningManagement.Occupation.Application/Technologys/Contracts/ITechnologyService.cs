using LearningManagement.Occupation.Application.Technologys.Dtos;
using LearningManagement.Occupation.Application.Technologys.Dtos.Create;
using LearningManagement.Occupation.Application.Technologys.Dtos.Get;

namespace LearningManagement.Occupation.Application.Technologys.Contracts;

public interface ITechnologyService {
    Task<CreateTechnologyResponse> CreateAsync(CreateTechnologyRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<TechnologyDto>> GetAllAsync(PaginationRequest request, TechnologySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<TechnologyDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateTechnologyRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}