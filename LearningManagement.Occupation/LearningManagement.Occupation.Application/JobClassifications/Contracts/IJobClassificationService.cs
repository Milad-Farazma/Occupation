using LearningManagement.Occupation.Application.JobClassifications.Dtos;
using LearningManagement.Occupation.Application.JobClassifications.Dtos.Create;
using LearningManagement.Occupation.Application.JobClassifications.Dtos.Get;

namespace LearningManagement.Occupation.Application.JobClassifications.Contracts;

public interface IJobClassificationService {
    Task<CreateJobClassificationResponse> CreateAsync(CreateJobClassificationRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<JobClassificationDto>> GetAllAsync(PaginationRequest request, JobClassificationSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<JobClassificationDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateJobClassificationRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}