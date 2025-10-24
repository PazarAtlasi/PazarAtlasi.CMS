using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Dtos;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Persistence.Context;
using System.Text.Json;

namespace PazarAtlasi.CMS.Infrastructure.Services
{
    /// <summary>
    /// SOLID: Single Responsibility - Provides template configurations from database
    /// Now reads configuration from SectionItemSetting and SectionItemFieldSetting entities
    /// </summary>
    public interface ITemplateConfigurationProvider
    {
        Task<TemplateSettingDto?> GetConfigurationAsync(int templateId, string templateKey);
    }

    public class TemplateConfigurationProvider : ITemplateConfigurationProvider
    {
        private readonly PazarAtlasiDbContext _context;

        public TemplateConfigurationProvider(PazarAtlasiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get template configuration from database asynchronously
        /// </summary>
        public async Task<TemplateSettingDto?> GetConfigurationAsync(int templateId, string templateKey)
        {
            // First get the template
            var template = await _context.Templates
                .FirstOrDefaultAsync(t => t.Id == templateId && t.TemplateKey == templateKey && t.IsActive);

            if (template == null)
                return null;

            // Then get the SectionItemSettings for this template
            var sectionItemSetting = await _context.SectionItemSettings
                .Where(sis => sis.TemplateId == templateId && !sis.IsDeleted)
                .Include(sis => sis.Fields.OrderBy(f => f.SortOrder))
                    .ThenInclude(f => f.Translations)
                .Include(sis => sis.Translations)
                .Include(sis => sis.ChildSettings) // Nested items
                    .ThenInclude(cs => cs.Fields.OrderBy(f => f.SortOrder))
                        .ThenInclude(f => f.Translations)
                .Include(sis => sis.ChildSettings)
                    .ThenInclude(cs => cs.Translations)
                .OrderBy(sis => sis.SortOrder)
                .FirstOrDefaultAsync();

            if (sectionItemSetting == null)
                return null;

            // Use the first one as default (or you can add logic to select specific one)

            return MapToTemplateConfiguration(template, sectionItemSetting);
        }


        /// <summary>
        /// Map Template entity to TemplateConfiguration DTO
        /// </summary>
        private TemplateSettingDto MapToTemplateConfiguration(Template template, SectionItemSetting defaultSectionItemSetting)
        {
            var config = new TemplateSettingDto
            {
                TemplateId = template.Id,
                TemplateName = template.Name,
                TemplateKey = template.TemplateKey,
                SectionItemSetting = MapToSectionItemSetting(defaultSectionItemSetting)
            };

            return config;
        }

        /// <summary>
        /// Recursively map SectionItemSetting to SectionItemConfiguration
        /// </summary>
        private SectionItemSettingDto MapToSectionItemSetting(SectionItemSetting setting)
        {
            var itemConfig = new SectionItemSettingDto
            {
                AllowDynamicSectionItems = setting.AllowDynamicSectionItems,
                ItemType = setting.ItemType,
                Translations = setting.Translations
                    .Select(t => new SectionItemSettingTranslationDto
                    {
                        LanguageId = t.LanguageId,
                        Title = t.Title,
                        Description = t.Description
                    })
                    .ToList(),
                Fields = setting.Fields
                    .Where(f => !f.IsDeleted)
                    .OrderBy(f => f.SortOrder)
                    .Select(f => MapToSectionItemFieldDto(f))
                    .ToList(),
                ChildSectionItemSettings = setting.ChildSettings
                    .Where(cs => !cs.IsDeleted)
                    .OrderBy(cs => cs.SortOrder)
                    .Select(cs => MapToSectionItemSetting(cs)) // RECURSIVE
                    .ToList(),
                UIConfiguration = new SectionItemUISettingDto()
                {
                    Layout = "list",
                    ShowPreview = true,
                    ShowReorder = true,
                    AddButtonText = $"Add {setting.ItemType}"
                }
            };

            return itemConfig;
        }

        /// <summary>
        /// Map SectionItemFieldSetting to SectionItemFieldDto
        /// </summary>
        private SectionItemFieldSettingDto MapToSectionItemFieldDto(SectionItemFieldSetting fieldSetting)
        {
            // Parse options from JSON
            List<string>? options = null;
            if (!string.IsNullOrEmpty(fieldSetting.OptionsJson))
            {
                try
                {
                    options = JsonSerializer.Deserialize<List<string>>(fieldSetting.OptionsJson);
                }
                catch
                {
                    options = null;
                }
            }

            return new  SectionItemFieldSettingDto
            {
                FieldKey = fieldSetting.FieldKey,
                Type = fieldSetting.Type,
                Required = fieldSetting.Required,
                MaxLength = fieldSetting.MaxLength,
                Placeholder = fieldSetting.Placeholder,
                DefaultValue = fieldSetting.DefaultValue,
                IsTranslatable = fieldSetting.IsTranslatable,
                Options = options,
                Translations = fieldSetting.Translations
                    .Select(t => new SectionItemFieldTranslationDto
                    {
                        LanguageId = t.LanguageId,
                        Label = t.Label,
                        Description = t.Description
                    })
                    .ToList()
            };
        }
    }
}
