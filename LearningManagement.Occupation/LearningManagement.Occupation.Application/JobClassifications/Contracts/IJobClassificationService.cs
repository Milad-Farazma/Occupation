using LearningManagement.Occupation.Application.JobClassifications.Dtos;
using LearningManagement.Occupation.Application.JobClassifications.Dtos.Create;
using LearningManagement.Occupation.Application.JobClassifications.Dtos.Get;

namespace LearningManagement.Occupation.Application.JobClassifications.Contracts;

public interface IJobClassificationService {
    Task<CreateJobClassificationResponse> CreateAsync(CreateJobClassificationRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<JobClassificationDto>> GetAllAsync(PaginationRequest request, JobClassificationSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<JobClassificationDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateJobClassificationRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}