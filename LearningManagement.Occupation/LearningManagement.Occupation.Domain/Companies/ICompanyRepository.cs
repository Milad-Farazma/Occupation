using LearningManagement.Occupation.Domain.Companies.Models;

namespace LearningManagement.Occupation.Domain.Companies;

public interface ICompanyRepository {
    Task<List<Company>> GetAllAsync(bool asNoTracking = true, CancellationToken cancellationToken = default);
    Task<Company?> GetByIdAsync(long id, bool asNoTracking = true, CancellationToken cancellationToken = default);
    void Add(Company company);
    void Update(Company product);
    void Remove(Company product);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(long id, CancellationToken cancellationToken = default);
}