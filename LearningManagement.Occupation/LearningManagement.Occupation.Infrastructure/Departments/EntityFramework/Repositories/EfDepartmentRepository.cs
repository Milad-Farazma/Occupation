using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Domain.Departments.Models;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.Infrastructure.Departments.EntityFramework.Repositories;

public class EfDepartmentRepository(ApplicationDbContext context)
    : EfGenericRepository<Department>(context), IDepartmentRepository;