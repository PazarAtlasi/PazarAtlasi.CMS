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
        Task<TemplateConfiguration?> GetConfigurationAsync(int templateId, string templateKey);
        TemplateConfiguration? GetConfiguration(int templateId, string templateKey);
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
        public async Task<TemplateConfiguration?> GetConfigurationAsync(int templateId, string templateKey)
        {
            var template = await _context.Templates
                .Include(t => t.SectionItemSettings.Where(s => s.ParentSettingId == null)) // Only root level settings
                    .ThenInclude(sis => sis.Fields.OrderBy(f => f.SortOrder))
                        .ThenInclude(f => f.Translations)
                .Include(t => t.SectionItemSettings.Where(s => s.ParentSettingId == null))
                    .ThenInclude(sis => sis.Translations)
                .Include(t => t.SectionItemSettings.Where(s => s.ParentSettingId == null))
                    .ThenInclude(sis => sis.ChildSettings) // Nested items
                        .ThenInclude(cs => cs.Fields.OrderBy(f => f.SortOrder))
                            .ThenInclude(f => f.Translations)
                .Include(t => t.SectionItemSettings.Where(s => s.ParentSettingId == null))
                    .ThenInclude(sis => sis.ChildSettings)
                        .ThenInclude(cs => cs.Translations)
                .FirstOrDefaultAsync(t => t.Id == templateId && t.TemplateKey == templateKey && t.IsActive);

            if (template == null)
                return null;

            return MapToTemplateConfiguration(template);
        }

        /// <summary>
        /// Get template configuration from database synchronously (for backward compatibility)
        /// </summary>
        public TemplateConfiguration? GetConfiguration(int templateId, string templateKey)
        {
            return GetConfigurationAsync(templateId, templateKey).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Map Template entity to TemplateConfiguration DTO
        /// </summary>
        private TemplateConfiguration MapToTemplateConfiguration(Template template)
        {
            var config = new TemplateConfiguration
            {
                TemplateId = template.Id,
                TemplateName = template.Name,
                TemplateKey = template.TemplateKey,
                SectionConfiguration = new SectionConfiguration
                {
                    MinSectionItemCount = template.SectionItemSettings
                        .Where(s => s.ParentSettingId == null)
                        .Min(s => (int?)s.MinItems) ?? 0,
                    MaxSectionItemCount = template.SectionItemSettings
                        .Where(s => s.ParentSettingId == null)
                        .Max(s => s.MaxItems),
                    DefaultSectionCount = template.SectionItemSettings
                        .Where(s => s.ParentSettingId == null)
                        .Sum(s => s.DefaultItemCount),
                    AllowDynamicSectionItems = template.SectionItemSettings
                        .Where(s => s.ParentSettingId == null)
                        .Any(s => s.AllowDynamicSectionItems),
                    SectionItems = template.SectionItemSettings
                        .Where(s => s.ParentSettingId == null && !s.IsDeleted)
                        .OrderBy(s => s.SortOrder)
                        .Select(sis => MapToSectionItemConfiguration(sis))
                        .ToList(),
                    SectionUIConfiguration = new SectionUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Section Item"
                    }
                }
            };

            return config;
        }

        /// <summary>
        /// Recursively map SectionItemSetting to SectionItemConfiguration
        /// </summary>
        private SectionItemConfiguration MapToSectionItemConfiguration(SectionItemSetting setting)
        {
            // Parse UI configuration from JSON
            ItemUIConfiguration? uiConfig = null;
            if (!string.IsNullOrEmpty(setting.UIConfigurationJson))
            {
                try
                {
                    uiConfig = JsonSerializer.Deserialize<ItemUIConfiguration>(setting.UIConfigurationJson);
                }
                catch
                {
                    uiConfig = new ItemUIConfiguration();
                }
            }

            var itemConfig = new SectionItemConfiguration
            {
                MinItems = setting.MinItems,
                MaxItems = setting.MaxItems,
                DefaultItemCount = setting.DefaultItemCount,
                AllowDynamicSectionItems = setting.AllowDynamicSectionItems,
                ItemType = setting.ItemType,
                Translations = setting.Translations
                    .Select(t => new SectionItemTranslationDto
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
                SectionItems = setting.ChildSettings
                    .Where(cs => !cs.IsDeleted)
                    .OrderBy(cs => cs.SortOrder)
                    .Select(cs => MapToSectionItemConfiguration(cs)) // RECURSIVE
                    .ToList(),
                UIConfiguration = uiConfig ?? new ItemUIConfiguration
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
        private SectionItemFieldDto MapToSectionItemFieldDto(SectionItemFieldSetting fieldSetting)
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

            return new SectionItemFieldDto
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
