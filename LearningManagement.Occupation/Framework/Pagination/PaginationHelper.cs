namespace Framework.Pagination;

public static class PaginationHelper {
    public static async Task<PaginatedResult<TEntity>> ApplyPagination<TEntity>(
        this IOrderedQueryable<TEntity?> entitiesQueryable,
        PaginationRequest request,
        CancellationToken cancellationToken = default)
        where TEntity : class, new() {
        var totalItems = await entitiesQueryable.LongCountAsync(cancellationToken);

        var query = entitiesQueryable
            .Skip(request.PageSize * request.PageIndex)
            .Take(request.PageSize);
        var entities = await query.ToListAsync(cancellationToken);

        var totalPagesCount = (ushort)Math.Ceiling((double)totalItems / request.PageSize);

        var hasNext = request.PageIndex < totalPagesCount - 1;
        var hasPrev = request.PageIndex > 0;

        return new PaginatedResult<TEntity>(
            request.PageIndex, request.PageSize, totalItems, totalPagesCount, hasNext, hasPrev, entities);
    }

    public static async Task<PaginatedResult<TResponseDto>> ApplyPagination<TEntity, TResponseDto>(
        this IOrderedQueryable<TEntity?> entitiesQueryable,
        PaginationRequest request,
        CancellationToken cancellationToken = default)
        where TEntity : class, new() {
        var pagination = await entitiesQueryable.ApplyPagination(request, cancellationToken);
        return new PaginatedResult<TResponseDto>(pagination.PageIndex, pagination.PageSize, pagination.Count, pagination.TotalPagesCount,
            pagination.HasNext, pagination.HasPrev,
            pagination.Data.Adapt<List<TResponseDto>>());
    }
}