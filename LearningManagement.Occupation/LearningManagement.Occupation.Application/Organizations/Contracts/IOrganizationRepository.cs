using LearningManagement.Occupation.Application.Shared;
using LearningManagement.Occupation.Domain.Organizations.Models;

namespace LearningManagement.Occupation.Application.Organizations.Contracts;

public interface IOrganizationRepository : IGenericRepository<Organization> {
    Task<List<Organization>> GetAllWithRelationsAsync(bool asNoTracking, CancellationToken cancellationToken = default);
}