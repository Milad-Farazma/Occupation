using Framework.Data.SoftDelete;
using Framework.Exceptions;
using Framework.Services.User;
using LearningManagement.Occupation.Application.Companies.Contracts;
using LearningManagement.Occupation.Application.Companies.Dto;
using LearningManagement.Occupation.Domain.Companies.Models;
using Mapster;

namespace LearningManagement.Occupation.Application.Companies.Services;

public class CompanyService(ICompanyRepository repo, IUserService userService) : ICompanyService {
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
        (await repo.GetAllWithRelationsAsync(true, cancellationToken: cancellationToken))
        .Select(c => c.Adapt<CompanyDto>());

    public async Task UpdateAsync(long id, UpdateCompanyRequest request, CancellationToken cancellationToken = default) {
        var company = await repo.GetByIdAsync(id, false, cancellationToken: cancellationToken);
        if (company is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Company)));

        request.Adapt(company);
        repo.Update(company);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var company = await repo.GetByIdAsync(id, false, cancellationToken: cancellationToken);
        if (company is null) throw new NotFoundException(new NotFoundError(id, nameof(company)));

        company.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}