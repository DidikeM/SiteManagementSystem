namespace SiteManagementSystem.WebUI.DTOs
{
    public class UpdateBlockDto
    {
        public int Id { get; set; }
        public string BlockName { get; set; } = null!;
        public int SiteId { get; set; }
    }
}
