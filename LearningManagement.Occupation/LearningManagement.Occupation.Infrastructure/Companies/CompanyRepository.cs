using Framework.Repositories.Generic;
using LearningManagement.Occupation.Domain.Companies;
using LearningManagement.Occupation.Domain.Companies.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Aquamation.Infrastructure.Companies;

public class CompanyRepository(AppDbContext context)
    : EfGenericRepository<Company, long>(context), ICompanyRepository {
    public Task<Company?> GetByIdAsync(long id, bool asNoTracking = true, CancellationToken cancellationToken = default) {
        var queryable = asNoTracking ? DbSet.AsNoTracking() : DbSet;
        return queryable.FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public void Add(Company company) {
        DbSet.Add(company);
    }

    public Task<bool> ExistsAsync(long id, CancellationToken cancellationToken = default) => DbSet.AnyAsync(item => item.Id == id, cancellationToken);
}