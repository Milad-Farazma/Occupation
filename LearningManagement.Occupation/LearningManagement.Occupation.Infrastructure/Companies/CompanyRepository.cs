using Framework.Repositories.Generic;
using LearningManagement.Occupation.Domain.Companies;
using LearningManagement.Occupation.Domain.Companies.Models;

namespace LearningManagement.Aquamation.Infrastructure.Companies;

public class CompanyRepository(AppDbContext context)
    : EfGenericRepository<Company, long>(context), ICompanyRepository;