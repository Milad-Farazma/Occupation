using Framework;

namespace LearningManagement.Occupation.Domain.Models;

public class ContactInfo : BaseEntity<long> {
    public int CityId { get; set; }
    public int ProvinceId { get; set; }
    public string EmailAddres { get; set; }
    public string WebsiteUrl { get; set; }
    public string InstagramAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
}