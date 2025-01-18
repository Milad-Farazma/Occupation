using Framework.Repositories.Generic;
using LearningManagement.Occupation.Domain.Company;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Aquamation.Infrastructure.Company;

public class CompanyRepository(AppDbContext context) : EfGenericRepository<Occupation.Domain.Company.Models.Company, long>(context), ICompanyRepository {
    public Task<Occupation.Domain.Company.Models.Company?> GetByIdAsync(long id, bool asNoTracking = true) {
        var queryable = asNoTracking ? DbSet.AsNoTracking() : DbSet;
        return queryable.FirstOrDefaultAsync(item => item.Id == id);
    }

    public void Add(Occupation.Domain.Company.Models.Company company) {
        DbSet.Add(company);
    }

    public Task<bool> ExistsAsync(long id) => DbSet.AnyAsync(item => item.Id == id);
}