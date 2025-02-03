using LearningManagement.Occupation.Application.Skills.Dtos;
using LearningManagement.Occupation.Domain.Skills;

namespace LearningManagement.Occupation.Application.Skills.Contracts;

public interface ISkillRepository {
    Task<PaginatedResult<Skill>> GetAllAsync(bool asNoTracking, PaginationRequest request, SkillSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<Skill?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(Skill entity);
    void Update(Skill entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}