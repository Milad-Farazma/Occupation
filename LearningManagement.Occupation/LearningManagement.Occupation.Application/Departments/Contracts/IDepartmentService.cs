using Framework.Pagination;
using LearningManagement.Occupation.Application.Departments.Dto;

namespace LearningManagement.Occupation.Application.Departments.Contracts;

public interface IDepartmentService {
    Task<CreateDepartmentResponse> CreateAsync(CreateDepartmentRequest request, CancellationToken cancellationToken = default);
    Task<DepartmentDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<PaginatedResult<DepartmentDto>> GetAllAsync(PaginationRequest request, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateDepartmentRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}