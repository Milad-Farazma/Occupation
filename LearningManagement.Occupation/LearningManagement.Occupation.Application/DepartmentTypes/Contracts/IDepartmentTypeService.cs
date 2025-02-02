using LearningManagement.Occupation.Application.DepartmentTypes.Dtos;
using LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Create;
using LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Get;

namespace LearningManagement.Occupation.Application.DepartmentTypes.Contracts;

public interface IDepartmentTypeService {
    Task<CreateDepartmentTypeResponse> CreateAsync(CreateDepartmentTypeRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<DepartmentTypeDto>> GetAllAsync(PaginationRequest request, DepartmentTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<DepartmentTypeDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateDepartmentTypeRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}