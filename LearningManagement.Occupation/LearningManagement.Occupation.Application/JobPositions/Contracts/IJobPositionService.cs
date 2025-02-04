using LearningManagement.Occupation.Application.JobPositions.Dtos;
using LearningManagement.Occupation.Application.JobPositions.Dtos.Create;
using LearningManagement.Occupation.Application.JobPositions.Dtos.Get;

namespace LearningManagement.Occupation.Application.JobPositions.Contracts;

public interface IJobPositionService {
    Task<CreateJobPositionResponse> CreateAsync(CreateJobPositionRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<JobPositionDto>> GetAllAsync(PaginationRequest request, JobPositionSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<JobPositionDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateJobPositionRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}