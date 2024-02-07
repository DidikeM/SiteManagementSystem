namespace SiteManagementSystem.WebUI.DTOs
{
    public class AddSiteDto
    {
        public string SiteName { get; set; } = null!;
        public string AddressDetail { get; set; } = null!;
        public int DistrictId { get; set; }
        public string TypeOfHeating { get; set; } = null!;
    }
}
