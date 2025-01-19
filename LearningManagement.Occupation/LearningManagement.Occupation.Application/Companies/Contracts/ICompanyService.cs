using LearningManagement.Occupation.Application.Companies.Dto;

namespace LearningManagement.Occupation.Application.Companies.Contracts;

public interface ICompanyService {
    Task<CompanyDto> CreateAsync(CreateCompanyRequest request, CancellationToken cancellationToken = default);
    Task<CompanyDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CompanyDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ErrorOr<Success>> UpdateAsync(long id, UpdateCompanyRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}