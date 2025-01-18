namespace LearningManagement.Occupation.Application.Contracts;

public interface IMapper {
    public TResult Adapt<TSource, TResult>(TSource source);
    T Adapt<T>(object source);
}