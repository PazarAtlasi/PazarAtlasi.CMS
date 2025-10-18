using PazarAtlasi.CMS.Application.Dtos;

namespace PazarAtlasi.CMS.Infrastructure.Services
{
    /// <summary>
    /// SOLID: Single Responsibility - Provides template configurations
    /// Strategy Pattern: Different configurations for different templates
    /// </summary>
    public interface ITemplateConfigurationProvider
    {
        TemplateConfiguration GetConfiguration(int templateId, string templateKey);
    }

    public class TemplateConfigurationProvider : ITemplateConfigurationProvider
    {
        // Template configuration registry - SOLID: Open/Closed Principle
        // Easy to extend with new configurations without modifying existing code
        private readonly Dictionary<string, Func<TemplateConfiguration>> _configurations;

        public TemplateConfigurationProvider()
        {
            _configurations = new Dictionary<string, Func<TemplateConfiguration>>
            {
                // Navbar Templates
                ["navbar-simple"] = () => CreateNavbarSimpleConfig(),
                ["navbar-megamenu"] = () => CreateNavbarMegaMenuConfig(),
                ["navbar-servicetabs"] = () => CreateNavbarServiceTabsConfig(),
                ["navbar-categorized"] = () => CreateNavbarCategorizedConfig(),

                // General Templates
                ["default"] = () => CreateDefaultConfig(),
                ["sequential"] = () => CreateSequentialConfig(),
                ["grid"] = () => CreateGridConfig(),
                ["masonry"] = () => CreateMasonryConfig(),
                ["carousel"] = () => CreateCarouselConfig(),
                ["list"] = () => CreateListConfig(),
                ["single-item"] = () => CreateSingleItemConfig(),
                ["multi-item"] = () => CreateMultiItemConfig(),
                ["accordion"] = () => CreateAccordionConfig(),
                ["tabs"] = () => CreateTabsConfig(),
            };
        }

        public TemplateConfiguration GetConfiguration(int templateId, string templateKey)
        {
            if (_configurations.TryGetValue(templateKey, out var configFactory))
            {
                var config = configFactory();
                config.TemplateId = templateId;
                return config;
            }

            // Fallback to default configuration
            return CreateDefaultConfig();
        }

        #region Navbar Configurations

        private TemplateConfiguration CreateNavbarSimpleConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Simple Navbar",
                TemplateKey = "navbar-simple",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 3,
                    MaxItems = 8,
                    DefaultItemCount = 3,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Menu,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Menu Title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 50, Placeholder = "e.g., Products, Services", IsTranslatable = true },
                        new() { Name = "icon", Label = "Icon (Optional)", Type = Domain.Common.SectionItemFieldType.Text, Placeholder = "fa fa-bars" }
                    },
                    NestedItems = new NestedSectionConfiguration
                    {
                        MinItems = 1,
                        MaxItems = 10,
                        DefaultItemCount = 3,
                        AllowDynamicItems = true,
                        ItemType = Domain.Common.SectionItemType.Link,
                        Fields = new List<SectionItemField>
                        {
                            new() { Name = "title", Label = "Link Text", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 50, Placeholder = "e.g., Home, About", IsTranslatable = true },
                            new() { Name = "url", Label = "URL", Type = Domain.Common.SectionItemFieldType.URL, Required = true, Placeholder = "/page-url or https://example.com" },
                            new() { Name = "icon", Label = "Icon (Optional)", Type = Domain.Common.SectionItemFieldType.Text, Placeholder = "fa fa-home" },
                            new() { Name = "openInNewTab", Label = "Open in New Tab", Type = Domain.Common.SectionItemFieldType.Checkbox, DefaultValue = "false" }
                        },
                        UIConfiguration = new ItemUIConfiguration
                        {
                            Layout = "list",
                            ShowPreview = true,
                            ShowReorder = true,
                            AddButtonText = "Add Dropdown Link",
                            IconClass = "fa-link"
                        }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Menu Item",
                        IconClass = "fa-bars"
                    }
                }
            };
        }

        private TemplateConfiguration CreateNavbarMegaMenuConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Mega Menu Navbar",
                TemplateKey = "navbar-megamenu",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 3,
                    MaxItems = 6,
                    DefaultItemCount = 3,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Menu,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Menu Title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 50, IsTranslatable = true },
                        new() { Name = "description", Label = "Description", Type = Domain.Common.SectionItemFieldType.Description, MaxLength = 200, Placeholder = "Brief description for mega menu", IsTranslatable = true },
                        new() { Name = "image", Label = "Featured Image", Type = Domain.Common.SectionItemFieldType.Image },
                        new() { Name = "icon", Label = "Icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-star" }
                    },
                    NestedItems = new NestedSectionConfiguration
                    {
                        MinItems = 2,
                        MaxItems = 15,
                        DefaultItemCount = 3,
                        AllowDynamicItems = true,
                        ItemType = Domain.Common.SectionItemType.Link,
                        Fields = new List<SectionItemField>
                        {
                            new() { Name = "title", Label = "Link Text", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 50, IsTranslatable = true },
                            new() { Name = "url", Label = "URL", Type = Domain.Common.SectionItemFieldType.URL, Required = true },
                            new() { Name = "description", Label = "Description", Type = Domain.Common.SectionItemFieldType.Description, MaxLength = 100, IsTranslatable = true },
                            new() { Name = "icon", Label = "Icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-chevron-right" }
                        },
                        UIConfiguration = new ItemUIConfiguration
                        {
                            Layout = "list",
                            ShowPreview = true,
                            ShowReorder = true,
                            AddButtonText = "Add Mega Menu Link",
                            IconClass = "fa-link"
                        }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "grid",
                        Columns = 2,
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Mega Menu Category",
                        IconClass = "fa-th-large"
                    }
                }
            };
        }

        private TemplateConfiguration CreateNavbarServiceTabsConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Service Tabs Navbar",
                TemplateKey = "navbar-servicetabs",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 3,
                    MaxItems = 6,
                    DefaultItemCount = 4,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Menu,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Tab Title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 50, IsTranslatable = true },
                        new() { Name = "description", Label = "Content", Type = Domain.Common.SectionItemFieldType.Description, Required = true, MaxLength = 500, IsTranslatable = true },
                        new() { Name = "url", Label = "Link URL", Type = Domain.Common.SectionItemFieldType.URL },
                        new() { Name = "icon", Label = "Tab Icon", Type = Domain.Common.SectionItemFieldType.Icon, Required = true, Placeholder = "fa fa-cog" }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Service Tab",
                        IconClass = "fa-folder-open"
                    }
                }
            };
        }

        private TemplateConfiguration CreateNavbarCategorizedConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Categorized Navbar",
                TemplateKey = "navbar-categorized",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 3,
                    MaxItems = 8,
                    DefaultItemCount = 3,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Menu,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Category Title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 50, IsTranslatable = true },
                        new() { Name = "icon", Label = "Icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-tag" }
                    },
                    NestedItems = new NestedSectionConfiguration
                    {
                        MinItems = 1,
                        MaxItems = 12,
                        DefaultItemCount = 3,
                        AllowDynamicItems = true,
                        ItemType = Domain.Common.SectionItemType.Link,
                        Fields = new List<SectionItemField>
                        {
                            new() { Name = "title", Label = "Item Title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 50, IsTranslatable = true },
                            new() { Name = "url", Label = "URL", Type = Domain.Common.SectionItemFieldType.URL, Required = true },
                            new() { Name = "icon", Label = "Icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-chevron-right" }
                        },
                        UIConfiguration = new ItemUIConfiguration
                        {
                            Layout = "list",
                            ShowPreview = true,
                            ShowReorder = true,
                            AddButtonText = "Add Category Link",
                            IconClass = "fa-link"
                        }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Category",
                        IconClass = "fa-tags"
                    }
                }
            };
        }

        #endregion

        #region General Template Configurations

        private TemplateConfiguration CreateDefaultConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Default Template",
                TemplateKey = "default",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 1,
                    MaxItems = null, // Unlimited
                    DefaultItemCount = 3,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 100, IsTranslatable = true },
                        new() { Name = "description", Label = "Description", Type = Domain.Common.SectionItemFieldType.Description, MaxLength = 500, IsTranslatable = true }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Item"
                    }
                }
            };
        }

        private TemplateConfiguration CreateCarouselConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Carousel",
                TemplateKey = "carousel",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 3,
                    MaxItems = 10,
                    DefaultItemCount = 5,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Image,
                    MediaType = Domain.Common.MediaType.Image,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "image", Label = "Slide Image", Type = Domain.Common.SectionItemFieldType.Image, Required = true },
                        new() { Name = "title", Label = "Slide Title", Type = Domain.Common.SectionItemFieldType.Title, MaxLength = 100, IsTranslatable = true },
                        new() { Name = "description", Label = "Slide Description", Type = Domain.Common.SectionItemFieldType.Description, MaxLength = 300, IsTranslatable = true },
                        new() { Name = "buttonText", Label = "Button Text", Type = Domain.Common.SectionItemFieldType.Text, MaxLength = 50, IsTranslatable = true },
                        new() { Name = "buttonUrl", Label = "Button URL", Type = Domain.Common.SectionItemFieldType.URL }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "grid",
                        Columns = 3,
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Slide",
                        IconClass = "fa-images"
                    }
                }
            };
        }

        private TemplateConfiguration CreateGridConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Grid Layout",
                TemplateKey = "grid",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 3,
                    MaxItems = 12,
                    DefaultItemCount = 6,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "image", Label = "Image", Type = Domain.Common.SectionItemFieldType.Image },
                        new() { Name = "title", Label = "Title", Type = Domain.Common.SectionItemFieldType.Text, Required = true, MaxLength = 100, IsTranslatable = true },
                        new() { Name = "description", Label = "Description", Type = Domain.Common.SectionItemFieldType.Description, MaxLength = 300, IsTranslatable = true },
                        new() { Name = "url", Label = "Link URL", Type = Domain.Common.SectionItemFieldType.URL }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "grid",
                        Columns = 3,
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Grid Item"
                    }
                }
            };
        }

        private TemplateConfiguration CreateMasonryConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Masonry Layout",
                TemplateKey = "masonry",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 4,
                    MaxItems = 20,
                    DefaultItemCount = 8,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Image,
                    MediaType = Domain.Common.MediaType.Image,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "image", Label = "Image", Type = Domain.Common.SectionItemFieldType.Image, Required = true },
                        new() { Name = "title", Label = "Title", Type = Domain.Common.SectionItemFieldType.Title, MaxLength = 100, IsTranslatable = true },
                        new() { Name = "description", Label = "Caption", Type = Domain.Common.SectionItemFieldType.Description, MaxLength = 200, IsTranslatable = true }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "grid",
                        Columns = 4,
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Image"
                    }
                }
            };
        }

        private TemplateConfiguration CreateSequentialConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Sequential Layout",
                TemplateKey = "sequential",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 2,
                    MaxItems = 10,
                    DefaultItemCount = 4,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Step Title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 100, IsTranslatable = true },
                        new() { Name = "description", Label = "Step Description", Type = Domain.Common.SectionItemFieldType.Description, Required = true, MaxLength = 500, IsTranslatable = true },
                        new() { Name = "icon", Label = "Step Icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-check" }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Step"
                    }
                }
            };
        }

        private TemplateConfiguration CreateListConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "List Layout",
                TemplateKey = "list",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 3,
                    MaxItems = 15,
                    DefaultItemCount = 5,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Item Text", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 200, IsTranslatable = true },
                        new() { Name = "icon", Label = "Icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-check-circle" },
                        new() { Name = "url", Label = "Link (Optional)", Type = Domain.Common.SectionItemFieldType.URL }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add List Item"
                    }
                }
            };
        }

        private TemplateConfiguration CreateSingleItemConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Single Item",
                TemplateKey = "single-item",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 1,
                    MaxItems = 1,
                    DefaultItemCount = 1,
                    AllowDynamicItems = false, // Fixed single item
                    ItemType = Domain.Common.SectionItemType.Text,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "image", Label = "Featured Image", Type = Domain.Common.SectionItemFieldType.Image },
                        new() { Name = "title", Label = "Title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 150, IsTranslatable = true },
                        new() { Name = "description", Label = "Description", Type = Domain.Common.SectionItemFieldType.Description, Required = true, MaxLength = 1000, IsTranslatable = true },
                        new() { Name = "buttonText", Label = "Button Text", Type = Domain.Common.SectionItemFieldType.Text, MaxLength = 50, IsTranslatable = true },
                        new() { Name = "buttonUrl", Label = "Button URL", Type = Domain.Common.SectionItemFieldType.URL }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = false,
                        AddButtonText = "" // No add button for single item
                    }
                }
            };
        }

        private TemplateConfiguration CreateMultiItemConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Multi Item",
                TemplateKey = "multi-item",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 2,
                    MaxItems = 8,
                    DefaultItemCount = 4,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "image", Label = "Image", Type = Domain.Common.SectionItemFieldType.Image },
                        new() { Name = "title", Label = "Title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 100, IsTranslatable = true },
                        new() { Name = "description", Label = "Description", Type = Domain.Common.SectionItemFieldType.Description, MaxLength = 300, IsTranslatable = true },
                        new() { Name = "url", Label = "Link", Type = Domain.Common.SectionItemFieldType.URL }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "grid",
                        Columns = 2,
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Item"
                    }
                }
            };
        }

        private TemplateConfiguration CreateAccordionConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Accordion",
                TemplateKey = "accordion",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 3,
                    MaxItems = 10,
                    DefaultItemCount = 5,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Panel Title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 150, IsTranslatable = true },
                        new() { Name = "description", Label = "Panel Content", Type = Domain.Common.SectionItemFieldType.Description, Required = true, MaxLength = 1000, IsTranslatable = true },
                        new() { Name = "icon", Label = "Icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-question-circle" }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Panel"
                    }
                }
            };
        }

        private TemplateConfiguration CreateTabsConfig()
        {
            return new TemplateConfiguration
            {
                TemplateName = "Tabs",
                TemplateKey = "tabs",
                SectionConfiguration = new SectionConfiguration
                {
                    MinItems = 2,
                    MaxItems = 8,
                    DefaultItemCount = 4,
                    AllowDynamicItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Tab Title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 50, IsTranslatable = true },
                        new() { Name = "description", Label = "Tab Content", Type = Domain.Common.SectionItemFieldType.Description, Required = true, MaxLength = 1000, IsTranslatable = true },
                        new() { Name = "icon", Label = "Tab Icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-star" }
                    },
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Tab"
                    }
                }
            };
        }

        #endregion
    }
}
