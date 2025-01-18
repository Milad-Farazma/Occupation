namespace LearningManagement.Occupation.Application;

public interface IMapper {
    public TResult Adapt<TSource, TResult>(TSource source);
    T Adapt<T>(object source);
}