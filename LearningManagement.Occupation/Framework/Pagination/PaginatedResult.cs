namespace Framework.Pagination;

public sealed record PaginatedResult<TEntity>(
    int PageIndex,
    int PageSize,
    long Count,
    ushort TotalPagesCount,
    bool HasNext,
    bool HasPrev,
    IEnumerable<TEntity?> Data);