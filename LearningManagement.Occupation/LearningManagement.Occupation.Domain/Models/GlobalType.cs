using Framework;

namespace LearningManagement.Occupation.Domain.Models;

public class GlobalType : BaseEntity<long> {
    public string Title { get; set; }
}