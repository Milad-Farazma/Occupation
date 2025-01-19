namespace Framework.Mappers;

public interface IMapper {
    public TResult Adapt<TSource, TResult>(TSource source);
    public TResult Adapt<TSource, TResult>(TSource source, TResult result);
    T Adapt<T>(object source);
}