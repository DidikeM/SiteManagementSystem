namespace SiteManagementSystem.WebUI.DTOs
{
    public class UpdateSiteDto
    {
        public int Id { get; set; }
        public string SiteName { get; set; } = null!;
        public int DistrictId { get; set; }
        public string AddressDetail { get; set; } = null!;
        public string TypeOfHeating { get; set; } = null!;
    }
}
