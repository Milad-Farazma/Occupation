using LearningManagement.Occupation.Application.Company.Dto;
using LearningManagement.Occupation.Domain.Company;

namespace LearningManagement.Occupation.Application.Company;

public class CompanyService(ICompanyRepository repo, IMapper mapper) : ICompanyService {
    public async Task<CompanyDto> CreateAsync(CreateCompanyCommand command) {
        var company = mapper.Adapt<Domain.Company.Models.Company>(command);
        repo.Add(company);
        await repo.SaveChangesAsync();

        return mapper.Adapt<CompanyDto>(company);
    }

    public async Task<CompanyDto?> GetByIdAsync(long id) {
        var company = await repo.GetByIdAsync(id);
        return company is null ? null : mapper.Adapt<CompanyDto>(company);
    }

    public async Task<IEnumerable<CompanyDto>> GetAllAsync() =>
        (await repo.GetAllAsync())
        .Select(mapper.Adapt<CompanyDto>);

    public async Task UpdateAsync(UpdateCompanyCommand command) {
        var company = await repo.GetByIdAsync(command.Id);
        if (company is null) return; //TODO: Throw error
        company = mapper.Adapt<Domain.Company.Models.Company>(command);
        repo.Update(company);
        
        await repo.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id) {
        var company = await repo.GetByIdAsync(id);
        if (company is null) return;
        repo.Remove(company);
        await repo.SaveChangesAsync();
    }
}