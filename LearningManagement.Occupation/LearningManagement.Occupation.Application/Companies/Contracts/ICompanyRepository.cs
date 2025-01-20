using LearningManagement.Occupation.Application.Shared;
using LearningManagement.Occupation.Domain.Companies.Models;

namespace LearningManagement.Occupation.Application.Companies.Contracts;

public interface ICompanyRepository: IGenericRepository<Company> {
    Task<List<Company>> GetAllWithRelationsAsync(bool asNoTracking, CancellationToken cancellationToken = default);
}