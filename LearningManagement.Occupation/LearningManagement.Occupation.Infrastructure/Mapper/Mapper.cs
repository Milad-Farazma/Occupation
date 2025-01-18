using LearningManagement.Occupation.Application;
using Mapster;

//TODO: Rename
namespace LearningManagement.Aquamation.Infrastructure.Mapper;

public class Mapper : IMapper {
    public TResult Adapt<TSource, TResult>(TSource source) => source.Adapt<TResult>();

    public T Adapt<T>(object source) => source.Adapt<T>();
}