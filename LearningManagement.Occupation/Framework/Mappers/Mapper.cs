using Mapster;

namespace Framework.Mappers;

public class Mapper : IMapper {
    public TResult Adapt<TSource, TResult>(TSource source) => source.Adapt<TResult>();
    public TResult Adapt<TSource, TResult>(TSource source, TResult result) => source.Adapt(result);

    public T Adapt<T>(object source) => source.Adapt<T>();
}