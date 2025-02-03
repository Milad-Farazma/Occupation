using LearningManagement.Occupation.Application.TechnologyTypes.Dtos;
using LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Create;
using LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Get;

namespace LearningManagement.Occupation.Application.TechnologyTypes.Contracts;

public interface ITechnologyTypeService {
    Task<CreateTechnologyTypeResponse> CreateAsync(CreateTechnologyTypeRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<TechnologyTypeDto>> GetAllAsync(PaginationRequest request, TechnologyTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<TechnologyTypeDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateTechnologyTypeRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}