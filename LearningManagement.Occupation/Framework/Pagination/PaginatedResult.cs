namespace Framework.Pagination;

public sealed class PaginatedResult<TEntity>(
    int pageIndex,
    int pageSize,
    long count,
    ushort totalPagesCount,
    bool hasNext,
    bool hasPrev,
    IEnumerable<TEntity?> data) {
    public int PageIndex { get; init; } = pageIndex;
    public int PageSize { get; init; } = pageSize;
    public long Count { get; init; } = count;
    public ushort TotalPagesCount { get; init; } = totalPagesCount;
    public bool HasNext { get; init; } = hasNext;
    public bool HasPrev { get; init; } = hasPrev;
    public IEnumerable<TEntity?> Data { get; init; } = data;

    public void Deconstruct(out int pageIndex, out int pageSize, out long count, out ushort totalPagesCount, out bool hasNext, out bool hasPrev,
        out IEnumerable<TEntity?> data) {
        pageIndex = PageIndex;
        pageSize = PageSize;
        count = Count;
        totalPagesCount = TotalPagesCount;
        hasNext = HasNext;
        hasPrev = HasPrev;
        data = Data;
    }
}