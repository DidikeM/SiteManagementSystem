namespace SiteManagementSystem.WebUI.DTOs
{
    public class SiteDto
    {
        public int Id { get; set; }
        public string SiteName { get; set; } = null!;
        public string AddressDetail { get; set; } = null!;
        public string DistrictName { get; set; } = null!;
        public int DistrictId { get; set; }
        public string CityName { get; set; } = null!;
        public int CityId { get; set; }
        public string TypeOfHeating { get; set; } = null!;
    }
}
