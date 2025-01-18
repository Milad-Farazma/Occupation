using LearningManagement.Occupation.Application.Companies.Dto;

namespace LearningManagement.Occupation.Application.Companies;

public interface ICompanyService {
    Task<CompanyDto> CreateAsync(CreateCompanyCommand command, CancellationToken cancellationToken = default);
    Task<CompanyDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CompanyDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateCompanyCommand command, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}