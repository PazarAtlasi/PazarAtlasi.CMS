namespace PazarAtlasi.CMS.Application.Dtos
{
    public class AvailableLayoutDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
    }
}
