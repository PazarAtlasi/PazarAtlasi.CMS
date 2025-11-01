namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// Request model for adding reusable section to layout
    /// </summary>
    public class AddReusableSectionToLayoutRequest
    {
        public int LayoutId { get; set; }
        public int SectionId { get; set; }
    }
}