namespace LearningManagement.Occupation.Domain.Companies;

public interface ICompanyRepository {
    Task<List<Models.Company>> GetAllAsync(bool asNoTracking = true);
    Task<Models.Company?> GetByIdAsync(long id, bool asNoTracking = true);
    void Add(Models.Company company);
    void Update(Models.Company product);
    void Remove(Models.Company product);
    Task<int> SaveChangesAsync();
    Task<bool> ExistsAsync(long id);
}