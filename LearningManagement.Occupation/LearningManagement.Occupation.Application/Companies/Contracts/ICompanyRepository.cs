using LearningManagement.Occupation.Domain.Companies.Models;

namespace LearningManagement.Occupation.Application.Companies.Contracts;

public interface ICompanyRepository {
    Task<List<Company>> GetAllAsync(bool asNoTracking, CancellationToken cancellationToken = default);
    Task<Company?> GetByIdAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    void Add(Company company);
    void Update(Company product);
    void Remove(Company product);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}