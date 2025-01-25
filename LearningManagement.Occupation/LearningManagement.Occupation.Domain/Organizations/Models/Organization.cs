using LearningManagement.Occupation.Domain.Departments.Models;
using LearningManagement.Occupation.Domain.OrganizationTypes;

namespace LearningManagement.Occupation.Domain.Organizations.Models;

public class Organization : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public int ProvinceId { get; set; }

    public string ProvinceTitle { get; set; } = default!;

    public int CityId { get; set; }

    public string CityTitle { get; set; } = default!;

    public string? CertificateCode { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? Email { get; set; }

    public string? LogoImg { get; set; }

    public string? Description { get; set; }

    public bool Accepted { get; set; } = true;

    public DateOnly? AcceptedDate { get; set; }

    public int? AcceptedUserId { get; set; }

    public bool IsPublic { get; set; } = true;

    public ICollection<Department> Departments { get; set; } = default!;
    public long OrganizationTypeId { get; set; }
    public OrganizationType OrganizationType { get; set; } = default!;
}