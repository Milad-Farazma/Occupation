using Framework.Services.User;
using Framework.SoftDelete;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Dto;
using LearningManagement.Occupation.Domain.Departments.Models;

namespace LearningManagement.Occupation.Application.Departments.Services;

public class DepartmentService(IDepartmentRepository repo, IMapper mapper, IUserService userService) : IDepartmentService {
    public async Task<DepartmentDto> CreateAsync(CreateDepartmentRequest request, CancellationToken cancellationToken = default) {
        var department = mapper.Adapt<Department>(request);
        repo.Add(department);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return mapper.Adapt<DepartmentDto>(department);
    }

    public async Task<DepartmentDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default) {
        var department = await repo.FindByIdAsync(id, asNoTracking: true, cancellationToken: cancellationToken);
        return department is null ? null : mapper.Adapt<DepartmentDto>(department);
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllAsync(CancellationToken cancellationToken = default) =>
        (await repo.GetAllAsync(asNoTracking: true, cancellationToken: cancellationToken))
        .Select(mapper.Adapt<DepartmentDto>);

    public async Task<ErrorOr<Success>> UpdateAsync(long id, UpdateDepartmentRequest request, CancellationToken cancellationToken = default) {
        var department = await repo.FindByIdAsync(id, cancellationToken: cancellationToken, asNoTracking: false);
        if (department is null)
            return Error.NotFound("Department.NotFound", "The Department with the specified ID was not found.");
        
        mapper.Adapt(request, department);
        repo.Update(department);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return Result.Success;
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var department = await repo.FindByIdAsync(id, cancellationToken: cancellationToken, asNoTracking: false);
        if (department is null) return;

        department.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}