using System.Data.Common;
using Microsoft.Extensions.Logging;

namespace Framework.Performance;

public class SlowQueryInterceptor(ILogger<SlowQueryInterceptor> logger, TimeSpan threshold) : DbCommandInterceptor {
    private static async Task<long> MeasureExecutionTimeAsync(Func<ValueTask> execute) {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        await execute();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    public override async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default) {
        var executionTime =
            await MeasureExecutionTimeAsync(async () => await base.ReaderExecutingAsync(command, eventData, result, cancellationToken));
        LogIfSlow(command, executionTime);
        return result;
    }

    public override async ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default) {
        var executionTime =
            await MeasureExecutionTimeAsync(async () => await base.NonQueryExecutingAsync(command, eventData, result, cancellationToken));
        LogIfSlow(command, executionTime);
        return result;
    }

    public override async ValueTask<InterceptionResult<object>> ScalarExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<object> result,
        CancellationToken cancellationToken = default) {
        var executionTime =
            await MeasureExecutionTimeAsync(async () => await base.ScalarExecutingAsync(command, eventData, result, cancellationToken));
        LogIfSlow(command, executionTime);
        return result;
    }

    private void LogIfSlow(DbCommand command, long executionTime) {
        if (executionTime > threshold.TotalMilliseconds) {
            logger.LogWarning("Slow query detected: {CommandText} took {ExecutionTime}ms", command.CommandText, executionTime);
        }
    }
}