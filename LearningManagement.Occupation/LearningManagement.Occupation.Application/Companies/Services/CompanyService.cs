using Framework.Services.User;
using Framework.SoftDelete;
using LearningManagement.Occupation.Application.Companies.Contracts;
using LearningManagement.Occupation.Application.Companies.Dto;
using LearningManagement.Occupation.Domain.Companies.Models;

namespace LearningManagement.Occupation.Application.Companies.Services;

public class CompanyService(ICompanyRepository repo, IMapper mapper, IUserService userService) : ICompanyService {
    public async Task<CompanyDto> CreateAsync(CreateCompanyRequest request, CancellationToken cancellationToken = default) {
        var company = mapper.Adapt<Company>(request);
        repo.Add(company);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return mapper.Adapt<CompanyDto>(company);
    }

    public async Task<CompanyDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default) {
        var company = await repo.FindByIdAsync(id, asNoTracking: true, cancellationToken: cancellationToken);
        return company is null ? null : mapper.Adapt<CompanyDto>(company);
    }

    public async Task<IEnumerable<CompanyDto>> GetAllAsync(CancellationToken cancellationToken = default) =>
        (await repo.GetAllAsync(asNoTracking: true, cancellationToken: cancellationToken))
        .Select(mapper.Adapt<CompanyDto>);

    public async Task<ErrorOr<Success>> UpdateAsync(long id, UpdateCompanyRequest request, CancellationToken cancellationToken = default) {
        var company = await repo.FindByIdAsync(id, cancellationToken: cancellationToken);
        if (company is null)
            return Error.NotFound("Company.NotFound", "The company with the specified ID was not found.");

        company = mapper.Adapt<Company>(request);
        repo.Update(company);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return Result.Success;
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var company = await repo.FindByIdAsync(id, cancellationToken: cancellationToken);
        if (company is null) return;
        
        company.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}