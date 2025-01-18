using LearningManagement.Occupation.Application.Companies.Dto;
using LearningManagement.Occupation.Application.Contracts;
using LearningManagement.Occupation.Domain.Companies;
using LearningManagement.Occupation.Domain.Companies.Models;

namespace LearningManagement.Occupation.Application.Companies;

public class CompanyService(ICompanyRepository repo, IMapper mapper) : ICompanyService {
    public async Task<CompanyDto> CreateAsync(CreateCompanyCommand command, CancellationToken cancellationToken = default) {
        var company = mapper.Adapt<Company>(command);
        repo.Add(company);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return mapper.Adapt<CompanyDto>(company);
    }

    public async Task<CompanyDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default) {
        var company = await repo.GetByIdAsync(id, asNoTracking: true, cancellationToken: cancellationToken);
        return company is null ? null : mapper.Adapt<CompanyDto>(company);
    }

    public async Task<IEnumerable<CompanyDto>> GetAllAsync(CancellationToken cancellationToken = default) =>
        (await repo.GetAllAsync(asNoTracking: true, cancellationToken: cancellationToken))
        .Select(mapper.Adapt<CompanyDto>);

    public async Task UpdateAsync(UpdateCompanyCommand command, CancellationToken cancellationToken = default) {
        var company = await repo.GetByIdAsync(command.Id, cancellationToken: cancellationToken);
        if (company is null) return; //TODO: Throw error
        company = mapper.Adapt<Company>(command);
        repo.Update(company);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var company = await repo.GetByIdAsync(id, cancellationToken: cancellationToken);
        if (company is null) return;
        repo.Remove(company);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}