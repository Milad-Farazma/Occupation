using LearningManagement.Occupation.Domain.Companies.Models;

namespace LearningManagement.Occupation.Domain.Companies;

public interface ICompanyRepository {
    Task<List<Company>> GetAllAsync(bool asNoTracking = true);
    Task<Company?> GetByIdAsync(long id, bool asNoTracking = true);
    void Add(Company company);
    void Update(Company product);
    void Remove(Company product);
    Task<int> SaveChangesAsync();
    Task<bool> ExistsAsync(long id);
}