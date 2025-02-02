using LearningManagement.Occupation.Domain.Departments;

namespace LearningManagement.Occupation.Domain.DepartmentTypes;

public class DepartmentType : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }


    public ICollection<Department> Departments { get; set; } = default!;
}