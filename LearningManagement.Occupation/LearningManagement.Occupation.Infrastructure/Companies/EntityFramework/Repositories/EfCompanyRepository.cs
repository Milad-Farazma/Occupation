using LearningManagement.Occupation.Application.Companies.Contracts;
using LearningManagement.Occupation.Domain.Companies.Models;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.Infrastructure.Companies.EntityFramework.Repositories;

public class EfCompanyRepository(ApplicationDbContext context)
    : EfGenericRepository<Company>(context), ICompanyRepository;