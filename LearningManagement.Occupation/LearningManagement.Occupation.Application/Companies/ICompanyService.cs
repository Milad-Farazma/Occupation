using LearningManagement.Occupation.Application.Companies.Dto;

namespace LearningManagement.Occupation.Application.Companies;

public interface ICompanyService {
    Task<CompanyDto> CreateAsync(CreateCompanyCommand command);
    Task<CompanyDto?> GetByIdAsync(long id);
    Task<IEnumerable<CompanyDto>> GetAllAsync();
    Task UpdateAsync(UpdateCompanyCommand command);
    Task DeleteAsync(long id);
}