namespace PazarAtlasi.CMS.Application.Dtos
{
    public class TemplateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TemplateType { get; set; }
        public string TemplateKey { get; set; }
        public string PreviewImageUrl { get; set; }
        public string ConfigurationSchema { get; set; }
    }
}
