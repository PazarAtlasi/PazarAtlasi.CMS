using System;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class Translation : BaseEntity
    {
        public string Key { get; set; }
        public string Language { get; set; }
        public string Value { get; set; }
    }
} 