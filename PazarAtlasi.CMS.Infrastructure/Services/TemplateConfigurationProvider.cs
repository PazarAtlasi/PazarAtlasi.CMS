using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Dtos;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Persistence.Context;
using System.Text.Json;

namespace PazarAtlasi.CMS.Infrastructure.Services
{
    /// <summary>
    /// SOLID: Single Responsibility - Provides template configurations from database
    /// Simplified version that reads from SectionItemField entities
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
        /// Get template configuration with example section items (for UI rendering and field definitions)
        /// </summary>
        public async Task<TemplateSettingDto?> GetConfigurationAsync(int templateId, string templateKey)
        {
            // Get the template with its fields and translations
            var template = await _context.Templates
                .FirstOrDefaultAsync(t => t.Id == templateId && t.TemplateKey == templateKey && t.IsActive);

            if (template == null)
                return null;

            // Get fields for this template with their translations
            var fields = await _context.SectionItemFields
                .Include(f => f.Translations)
                    .ThenInclude(t => t.Language)
                .Where(f => f.TemplateId == templateId && !f.IsDeleted)
                .OrderBy(f => f.SortOrder)
                .ToListAsync();

            // Get example section items that use this template (for demonstration)
            var exampleSectionItems = await _context.SectionItems
                .Include(si => si.FieldValues)
                    .ThenInclude(fv => fv.SectionItemField)
                        .ThenInclude(f => f.Translations)
                .Include(si => si.FieldValues)
                    .ThenInclude(fv => fv.Translations)
                .Include(si => si.Translations)
                .Where(si => si.TemplateId == templateId && !si.IsDeleted)
                .OrderBy(si => si.SortOrder)
                .Take(5) // Limit to 5 examples
                .ToListAsync();

            return MapToTemplateConfigurationWithExamples(template, fields, exampleSectionItems);
        }

        /// <summary>
        /// Map Template entity to TemplateConfiguration DTO with example section items
        /// </summary>
        private TemplateSettingDto MapToTemplateConfigurationWithExamples(Template template, List<SectionItemField> fields, List<SectionItem> exampleItems)
        {
            var config = new TemplateSettingDto
            {
                TemplateId = template.Id,
                TemplateName = template.Name,
                TemplateKey = template.TemplateKey,
                SectionItemSetting = new SectionItemSettingDto
                {
                    AllowDynamicSectionItems = true,
                    ItemType = SectionItemType.None,
                    Fields = fields.Select(f => MapToSectionItemFieldDto(f)).ToList(),
                    ChildSectionItemSettings = new List<SectionItemSettingDto>(),
                    UIConfiguration = new SectionItemUISettingDto
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Section Item"
                    }
                },
                // NEW: Add example section items
                ExampleItems = exampleItems.Select(item => MapToSectionItemDto(item, new List<SectionItem>())).ToList()
            };

            return config;
        }

        /// <summary>
        /// Map SectionItemField to SectionItemFieldDto
        /// </summary>
        private SectionItemFieldSettingDto MapToSectionItemFieldDto(SectionItemField field)
        {
            // Parse options from JSON
            List<string>? options = null;
            if (!string.IsNullOrEmpty(field.OptionsJson))
            {
                try
                {
                    options = JsonSerializer.Deserialize<List<string>>(field.OptionsJson);
                }
                catch
                {
                    options = null;
                }
            }

            // Map translations from database
            var translations = field.Translations?.Select(t => new SectionItemFieldTranslationDto
            {
                LanguageId = t.LanguageId,
                Label = t.Label,
                Description = t.Description
            }).ToList() ?? new List<SectionItemFieldTranslationDto>();

            // If no translations exist, create a default one
            if (!translations.Any())
            {
                translations.Add(new SectionItemFieldTranslationDto
                {
                    LanguageId = 1, // Default language - should be configurable
                    Label = field.FieldName,
                    Description = field.FieldName
                });
            }

            return new SectionItemFieldSettingDto
            {
                FieldKey = field.FieldKey,
                Type = field.Type,
                Required = field.Required,
                MaxLength = field.MaxLength,
                Placeholder = field.Placeholder,
                DefaultValue = field.DefaultValue,
                IsTranslatable = field.IsTranslatable,
                Options = options,
                Translations = translations
            };
        }


        /// <summary>
        /// Map SectionItem to SectionItemDto with nested structure
        /// </summary>
        private SectionItemDto MapToSectionItemDto(SectionItem item, List<SectionItem> allSectionItems)
        {
            // Get child items
            var childItems = allSectionItems
                .Where(si => si.ParentSectionItemId == item.Id)
                .Select(child => MapToSectionItemDto(child, allSectionItems))
                .ToList();

            // Map field values
            var fieldValues = item.FieldValues?.Select(fv => new SectionItemFieldValueDto
            {
                FieldKey = fv.SectionItemField?.FieldKey ?? "",
                FieldType = fv.SectionItemField?.Type ?? SectionItemFieldType.Text,
                Value = fv.Value,
                IsTranslatable = fv.SectionItemField?.IsTranslatable ?? false,
                FieldLabel = fv.SectionItemField?.Translations?.FirstOrDefault()?.Label ?? fv.SectionItemField?.FieldName ?? "",
                Translations = fv.Translations?.Select(t => new SectionItemFieldValueTranslationDto
                {
                    LanguageId = t.LanguageId,
                    Value = t.Value
                }).ToList() ?? new List<SectionItemFieldValueTranslationDto>()
            }).ToList() ?? new List<SectionItemFieldValueDto>();

            return new SectionItemDto
            {
                Id = item.Id,
                ParentId = item.ParentSectionItemId,
                Type = item.Type,
                Title = item.Title ?? "",
                Description = item.Description ?? "",
                IconClass = item.IconClass ?? "",
                SortOrder = item.SortOrder,
                AllowReorder = item.AllowReorder,
                AllowRemove = item.AllowRemove,
                FieldValues = fieldValues,
                ChildItems = childItems,
                Translations = item.Translations?.Select(t => new SectionItemTranslationDto
                {
                    LanguageId = t.LanguageId,
                    Name = t.Name ?? "",
                    Title = t.Title ?? "",
                    Description = t.Description ?? ""
                }).ToList() ?? new List<SectionItemTranslationDto>()
            };
        }
    }
}
