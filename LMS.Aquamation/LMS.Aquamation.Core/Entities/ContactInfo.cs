using Framework;

namespace LMS.Aquamation.Core.Entities;

public class ContactInfo : BaseEntity {
    public int CityId { get; set; }
    public int ProvinceId { get; set; }
    public string EmailAddres { get; set; }
    public string WebsiteUrl { get; set; }
    public string InstagramAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
}