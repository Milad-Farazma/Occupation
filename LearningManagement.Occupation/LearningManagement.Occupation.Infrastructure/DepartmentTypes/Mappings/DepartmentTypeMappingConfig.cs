using LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.DepartmentTypes;

namespace LearningManagement.Occupation.Infrastructure.DepartmentTypes.Mappings;

public class DepartmentTypeMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<DepartmentType, DepartmentTypeDto>.NewConfig()
            .Map(dest => dest.Departments, src => src.Departments);
    }
}