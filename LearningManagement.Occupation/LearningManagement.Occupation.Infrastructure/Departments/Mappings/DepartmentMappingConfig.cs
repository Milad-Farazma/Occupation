using LearningManagement.Occupation.Application.Departments.Dto;
using LearningManagement.Occupation.Domain.Departments.Models;

namespace LearningManagement.Occupation.Infrastructure.Departments.Mappings;

public class DepartmentMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<CreateDepartmentRequest, Department>.NewConfig()
            .Map(dest => dest.TypeId, src => src.TypeId)
            .Map(dest => dest.Title, src => src.Title);

        TypeAdapterConfig<Department, DepartmentDto>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.TypeId, src => src.TypeId)
            .Map(dest => dest.Title, src => src.Title);

        TypeAdapterConfig<UpdateDepartmentRequest, Department>
            .NewConfig()
            .Ignore(dest => dest.Id);
    }
}