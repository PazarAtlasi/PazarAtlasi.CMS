using PazarAtlasi.CMS.Application.Dtos;

namespace PazarAtlasi.CMS.Infrastructure.Services
{
    /// <summary>
    /// SOLID: Single Responsibility - Provides template configurations
    /// Strategy Pattern: Different configurations for different templates
    /// </summary>
    public interface ITemplateConfigurationProvider
    {
        TemplateConfigurationDto GetConfiguration(int templateId, string templateKey);
    }

    public class TemplateConfigurationProvider : ITemplateConfigurationProvider
    {
        // Template configuration registry - SOLID: Open/Closed Principle
        // Easy to extend with new configurations without modifying existing code
        private readonly Dictionary<string, Func<TemplateConfigurationDto>> _configurations;

        public TemplateConfigurationProvider()
        {
            _configurations = new Dictionary<string, Func<TemplateConfigurationDto>>
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

        public TemplateConfigurationDto GetConfiguration(int templateId, string templateKey)
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

        private TemplateConfigurationDto CreateNavbarSimpleConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Simple Navbar",
                TemplateKey = "navbar-simple",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 8,
                    DefaultItems = 3,
                    AllowDynamicItems = true,
                    ItemType = "Menu",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Menu Title", Type = "text", Required = true, MaxLength = 50, Placeholder = "e.g., Products, Services", IsTranslatable = true },
                        new() { Name = "icon", Label = "Icon (Optional)", Type = "text", Placeholder = "fa fa-bars" }
                    },
                    NestedItems = new NestedItemConfiguration
                    {
                        MinItems = 1,
                        MaxItems = 10,
                        DefaultItems = 3,
                        AllowDynamicItems = true,
                        ItemType = "Link",
                        Fields = new List<SectionItemField>
                        {
                            new() { Name = "title", Label = "Link Text", Type = "text", Required = true, MaxLength = 50, Placeholder = "e.g., Home, About", IsTranslatable = true },
                            new() { Name = "url", Label = "URL", Type = "url", Required = true, Placeholder = "/page-url or https://example.com" },
                            new() { Name = "icon", Label = "Icon (Optional)", Type = "text", Placeholder = "fa fa-home" },
                            new() { Name = "openInNewTab", Label = "Open in New Tab", Type = "checkbox", DefaultValue = "false" }
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

        private TemplateConfigurationDto CreateNavbarMegaMenuConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Mega Menu Navbar",
                TemplateKey = "navbar-megamenu",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 6,
                    DefaultItems = 3,
                    AllowDynamicItems = true,
                    ItemType = "Menu",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Menu Title", Type = "text", Required = true, MaxLength = 50 },
                        new() { Name = "description", Label = "Description", Type = "textarea", MaxLength = 200, Placeholder = "Brief description for mega menu" },
                        new() { Name = "image", Label = "Featured Image", Type = "image" },
                        new() { Name = "icon", Label = "Icon", Type = "text", Placeholder = "fa fa-star" }
                    },
                    NestedItems = new NestedItemConfiguration
                    {
                        MinItems = 2,
                        MaxItems = 15,
                        DefaultItems = 3,
                        AllowDynamicItems = true,
                        ItemType = "Link",
                        Fields = new List<SectionItemField>
                        {
                            new() { Name = "title", Label = "Link Text", Type = "text", Required = true, MaxLength = 50, IsTranslatable = true },
                            new() { Name = "url", Label = "URL", Type = "url", Required = true },
                            new() { Name = "description", Label = "Description", Type = "textarea", MaxLength = 100, IsTranslatable = true },
                            new() { Name = "icon", Label = "Icon", Type = "text", Placeholder = "fa fa-chevron-right" }
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

        private TemplateConfigurationDto CreateNavbarServiceTabsConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Service Tabs Navbar",
                TemplateKey = "navbar-servicetabs",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 6,
                    DefaultItems = 4,
                    AllowDynamicItems = true,
                    ItemType = "Link",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Tab Title", Type = "text", Required = true, MaxLength = 50 },
                        new() { Name = "description", Label = "Content", Type = "textarea", Required = true, MaxLength = 500 },
                        new() { Name = "url", Label = "Link URL", Type = "url" },
                        new() { Name = "icon", Label = "Tab Icon", Type = "text", Required = true, Placeholder = "fa fa-cog" }
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

        private TemplateConfigurationDto CreateNavbarCategorizedConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Categorized Navbar",
                TemplateKey = "navbar-categorized",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 8,
                    DefaultItems = 3,
                    AllowDynamicItems = true,
                    ItemType = "Menu",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Category Title", Type = "text", Required = true, MaxLength = 50 },
                        new() { Name = "icon", Label = "Icon", Type = "text", Placeholder = "fa fa-tag" }
                    },
                    NestedItems = new NestedItemConfiguration
                    {
                        MinItems = 1,
                        MaxItems = 12,
                        DefaultItems = 3,
                        AllowDynamicItems = true,
                        ItemType = "Link",
                        Fields = new List<SectionItemField>
                        {
                            new() { Name = "title", Label = "Item Title", Type = "text", Required = true, MaxLength = 50, IsTranslatable = true },
                            new() { Name = "url", Label = "URL", Type = "url", Required = true },
                            new() { Name = "icon", Label = "Icon", Type = "text", Placeholder = "fa fa-chevron-right" }
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

        private TemplateConfigurationDto CreateDefaultConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Default Template",
                TemplateKey = "default",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 1,
                    MaxItems = null, // Unlimited
                    DefaultItems = 3,
                    AllowDynamicItems = true,
                    ItemType = "Text",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Title", Type = "text", Required = true, MaxLength = 100 },
                        new() { Name = "description", Label = "Description", Type = "textarea", MaxLength = 500 }
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

        private TemplateConfigurationDto CreateCarouselConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Carousel",
                TemplateKey = "carousel",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 10,
                    DefaultItems = 5,
                    AllowDynamicItems = true,
                    ItemType = "Image",
                    MediaType = "Image",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "image", Label = "Slide Image", Type = "image", Required = true },
                        new() { Name = "title", Label = "Slide Title", Type = "text", MaxLength = 100 },
                        new() { Name = "description", Label = "Slide Description", Type = "textarea", MaxLength = 300 },
                        new() { Name = "buttonText", Label = "Button Text", Type = "text", MaxLength = 50 },
                        new() { Name = "buttonUrl", Label = "Button URL", Type = "url" }
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

        private TemplateConfigurationDto CreateGridConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Grid Layout",
                TemplateKey = "grid",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 12,
                    DefaultItems = 6,
                    AllowDynamicItems = true,
                    ItemType = "Text",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "image", Label = "Image", Type = "image" },
                        new() { Name = "title", Label = "Title", Type = "text", Required = true, MaxLength = 100 },
                        new() { Name = "description", Label = "Description", Type = "textarea", MaxLength = 300 },
                        new() { Name = "url", Label = "Link URL", Type = "url" }
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

        private TemplateConfigurationDto CreateMasonryConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Masonry Layout",
                TemplateKey = "masonry",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 4,
                    MaxItems = 20,
                    DefaultItems = 8,
                    AllowDynamicItems = true,
                    ItemType = "Image",
                    MediaType = "Image",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "image", Label = "Image", Type = "image", Required = true },
                        new() { Name = "title", Label = "Title", Type = "text", MaxLength = 100 },
                        new() { Name = "description", Label = "Caption", Type = "textarea", MaxLength = 200 }
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

        private TemplateConfigurationDto CreateSequentialConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Sequential Layout",
                TemplateKey = "sequential",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 2,
                    MaxItems = 10,
                    DefaultItems = 4,
                    AllowDynamicItems = true,
                    ItemType = "Text",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Step Title", Type = "text", Required = true, MaxLength = 100 },
                        new() { Name = "description", Label = "Step Description", Type = "textarea", Required = true, MaxLength = 500 },
                        new() { Name = "icon", Label = "Step Icon", Type = "text", Placeholder = "fa fa-check" }
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

        private TemplateConfigurationDto CreateListConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "List Layout",
                TemplateKey = "list",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 15,
                    DefaultItems = 5,
                    AllowDynamicItems = true,
                    ItemType = "Text",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Item Text", Type = "text", Required = true, MaxLength = 200 },
                        new() { Name = "icon", Label = "Icon", Type = "text", Placeholder = "fa fa-check-circle" },
                        new() { Name = "url", Label = "Link (Optional)", Type = "url" }
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

        private TemplateConfigurationDto CreateSingleItemConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Single Item",
                TemplateKey = "single-item",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 1,
                    MaxItems = 1,
                    DefaultItems = 1,
                    AllowDynamicItems = false, // Fixed single item
                    ItemType = "Text",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "image", Label = "Featured Image", Type = "image" },
                        new() { Name = "title", Label = "Title", Type = "text", Required = true, MaxLength = 150 },
                        new() { Name = "description", Label = "Description", Type = "textarea", Required = true, MaxLength = 1000 },
                        new() { Name = "buttonText", Label = "Button Text", Type = "text", MaxLength = 50 },
                        new() { Name = "buttonUrl", Label = "Button URL", Type = "url" }
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

        private TemplateConfigurationDto CreateMultiItemConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Multi Item",
                TemplateKey = "multi-item",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 2,
                    MaxItems = 8,
                    DefaultItems = 4,
                    AllowDynamicItems = true,
                    ItemType = "Text",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "image", Label = "Image", Type = "image" },
                        new() { Name = "title", Label = "Title", Type = "text", Required = true, MaxLength = 100 },
                        new() { Name = "description", Label = "Description", Type = "textarea", MaxLength = 300 },
                        new() { Name = "url", Label = "Link", Type = "url" }
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

        private TemplateConfigurationDto CreateAccordionConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Accordion",
                TemplateKey = "accordion",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 10,
                    DefaultItems = 5,
                    AllowDynamicItems = true,
                    ItemType = "Text",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Panel Title", Type = "text", Required = true, MaxLength = 150 },
                        new() { Name = "description", Label = "Panel Content", Type = "textarea", Required = true, MaxLength = 1000 },
                        new() { Name = "icon", Label = "Icon", Type = "text", Placeholder = "fa fa-question-circle" }
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

        private TemplateConfigurationDto CreateTabsConfig()
        {
            return new TemplateConfigurationDto
            {
                TemplateName = "Tabs",
                TemplateKey = "tabs",
                ItemConfiguration = new SectionItemConfiguration
                {
                    MinItems = 2,
                    MaxItems = 8,
                    DefaultItems = 4,
                    AllowDynamicItems = true,
                    ItemType = "Text",
                    Fields = new List<SectionItemField>
                    {
                        new() { Name = "title", Label = "Tab Title", Type = "text", Required = true, MaxLength = 50 },
                        new() { Name = "description", Label = "Tab Content", Type = "textarea", Required = true, MaxLength = 1000 },
                        new() { Name = "icon", Label = "Tab Icon", Type = "text", Placeholder = "fa fa-star" }
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
