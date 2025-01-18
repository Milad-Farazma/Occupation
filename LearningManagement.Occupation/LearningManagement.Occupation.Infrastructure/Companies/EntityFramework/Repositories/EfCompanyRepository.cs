using Framework.Repositories.Generic;
using LearningManagement.Occupation.Application.Companies.Contracts;
using LearningManagement.Occupation.Domain.Companies.Models;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.Infrastructure.Companies.EntityFramework.Repositories;

public class EfCompanyRepository(AppDbContext context)
    : EfGenericRepository<Company>(context), ICompanyRepository;