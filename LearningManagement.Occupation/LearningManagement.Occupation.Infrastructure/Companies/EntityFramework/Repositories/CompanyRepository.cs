using LearningManagement.Occupation.Application.Companies.Contracts;
using LearningManagement.Occupation.Domain.Companies.Models;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.Infrastructure.Companies.EntityFramework.Repositories;

public class CompanyRepository(ApplicationDbContext context) : EfGenericRepository<Company>(context: context), ICompanyRepository {
    public Task<List<Company>> GetAllWithRelationsAsync(bool asNoTracking, CancellationToken cancellationToken = default) {
        return DbSet.Include(c => c.Department).ToListAsync(cancellationToken: cancellationToken);
    }
}