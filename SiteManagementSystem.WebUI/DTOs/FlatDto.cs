namespace SiteManagementSystem.WebUI.DTOs
{
    public class FlatDto
    {
        public int Id { get; set; }
        public string FlatNumber { get; set; } = null!;
        public int Floor { get; set; }
        public int Area { get; set; }
        public string Description { get; set; } = null!;
    }
}
