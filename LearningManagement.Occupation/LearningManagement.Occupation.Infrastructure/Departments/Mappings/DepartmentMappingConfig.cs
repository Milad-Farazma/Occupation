using LearningManagement.Occupation.Application.Departments.Dtos.Get;
using LearningManagement.Occupation.Domain.Departments;

namespace LearningManagement.Occupation.Infrastructure.Departments.Mappings;

public class DepartmentMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<Department, DepartmentDto>.NewConfig()
            .Map(dest => dest.DepartmentType, src => src.DepartmentType)
            .Map(dest => dest.Organization, src => src.Organization);
    }
}