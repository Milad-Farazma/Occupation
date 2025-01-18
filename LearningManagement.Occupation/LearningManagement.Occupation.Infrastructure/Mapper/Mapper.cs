using LearningManagement.Occupation.Application.Contracts;
using Mapster;

namespace LearningManagement.Occupation.Infrastructure.Mapper;

public class Mapper : IMapper {
    public TResult Adapt<TSource, TResult>(TSource source) => source.Adapt<TResult>();

    public T Adapt<T>(object source) => source.Adapt<T>();
}