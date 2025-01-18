using LearningManagement.Occupation.Application.Company.Dto;

namespace LearningManagement.Occupation.Application.Company;

public interface ICompanyService {
    Task<CompanyDto> CreateAsync(CreateCompanyCommand command);
    Task<CompanyDto?> GetByIdAsync(long id);
    Task<IEnumerable<CompanyDto>> GetAllAsync();
    Task UpdateAsync(UpdateCompanyCommand command);
    Task DeleteAsync(long id);
}