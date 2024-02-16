namespace SiteManagementSystem.WebUI.DTOs
{
    public class AddFlatDto
    {
        public int FlatNumber { get; set; }
        public int BlockId { get; set; }
        public int Floor { get; set; }
        public int Area { get; set; }
        public string Description { get; set; } = null!;
    }
}
