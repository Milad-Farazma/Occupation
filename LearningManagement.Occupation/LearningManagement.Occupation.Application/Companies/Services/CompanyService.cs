using Framework.Data.SoftDelete;
using Framework.Services.User;
using LearningManagement.Occupation.Application.Companies.Contracts;
using LearningManagement.Occupation.Application.Companies.Dto;
using LearningManagement.Occupation.Application.Shared;
using LearningManagement.Occupation.Domain.Companies.Models;
using Mapster;

namespace LearningManagement.Occupation.Application.Companies.Services;

public class CompanyService(IGenericRepository<Company> repo, IUserService userService) : ICompanyService {
    public async Task<CompanyDto> CreateAsync(CreateCompanyRequest request, CancellationToken cancellationToken = default) {
        var company = request.Adapt<Company>();
        repo.Add(company);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return company.Adapt<CompanyDto>();
    }

    public async Task<CompanyDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default) {
        var company = await repo.GetByIdAsync(id, asNoTracking: true, cancellationToken: cancellationToken);
        return company?.Adapt<CompanyDto>();
    }

    public async Task<IEnumerable<CompanyDto>> GetAllAsync(CancellationToken cancellationToken = default) =>
        (await repo.GetAllAsync(asNoTracking: true, cancellationToken: cancellationToken))
        .Select(c => c.Adapt<CompanyDto>());

    public async Task<ErrorOr<Success>> UpdateAsync(long id, UpdateCompanyRequest request, CancellationToken cancellationToken = default) {
        var company = await repo.GetByIdAsync(id, cancellationToken: cancellationToken, asNoTracking: false);
        if (company is null)
            return Error.NotFound("Company.NotFound", "The company with the specified ID was not found.");

        request.Adapt(company);
        repo.Update(company);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
        return Result.Success;
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var company = await repo.GetByIdAsync(id, cancellationToken: cancellationToken, asNoTracking: false);
        if (company is null) return;
        
        company.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}