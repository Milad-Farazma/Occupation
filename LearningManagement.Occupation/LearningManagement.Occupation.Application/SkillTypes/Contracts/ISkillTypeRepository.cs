using LearningManagement.Occupation.Application.SkillTypes.Dtos;
using LearningManagement.Occupation.Domain.SkillTypes;

namespace LearningManagement.Occupation.Application.SkillTypes.Contracts;

public interface ISkillTypeRepository {
    Task<PaginatedResult<SkillType>> GetAllAsync(bool asNoTracking, PaginationRequest request, SkillTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<SkillType?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(SkillType entity);
    void Update(SkillType entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}