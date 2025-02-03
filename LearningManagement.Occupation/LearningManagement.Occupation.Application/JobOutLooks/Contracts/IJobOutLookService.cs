using LearningManagement.Occupation.Application.JobOutLooks.Dtos;
using LearningManagement.Occupation.Application.JobOutLooks.Dtos.Create;
using LearningManagement.Occupation.Application.JobOutLooks.Dtos.Get;

namespace LearningManagement.Occupation.Application.JobOutLooks.Contracts;

public interface IJobOutLookService {
    Task<CreateJobOutLookResponse> CreateAsync(CreateJobOutLookRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<JobOutLookDto>> GetAllAsync(PaginationRequest request, JobOutLookSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<JobOutLookDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateJobOutLookRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}