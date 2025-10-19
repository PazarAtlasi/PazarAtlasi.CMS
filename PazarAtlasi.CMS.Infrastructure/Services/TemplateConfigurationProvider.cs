using PazarAtlasi.CMS.Application.Dtos;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Persistence.EntityConfigurations.Content;

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
                    MinSectionItemCount = 2,
                    MaxSectionItemCount = 6,
                    DefaultSectionCount = 2,
                    AllowDynamicSectionItems = false, // Logo + Menu items fixed
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        // Logo Configuration
                        new SectionItemConfiguration
                        {
                            MinItems = 1,
                            MaxItems = 1,
                            DefaultItemCount = 1,
                            AllowDynamicSectionItems = false,
                            ItemType = Domain.Common.SectionItemType.Logo,
                            Translations = new List<SectionItemTranslationDto>
                            {
                                new SectionItemTranslationDto
                                {
                                    LanguageId = 1033, // en-US
                                            Title = "Logo",
                                            Description = "Website Logo"
                                        },
                                new SectionItemTranslationDto
                                        {
                                    LanguageId = 1055, // tr-TR
                                            Title = "Logo",
                                    Description = "Web sitesi logosu"
                                }
                            },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "image", 
                                    Type = Domain.Common.SectionItemFieldType.Image, 
                                    Required = true,
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Logo Image", Description = "Upload your logo image" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Logo Resmi", Description = "Logo resminizi yükleyin" }
                                    }
                                },
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "altText", 
                                    Type = Domain.Common.SectionItemFieldType.Text, 
                                    MaxLength = 100, 
                                    IsTranslatable = true,
                                    Placeholder = "Logo alt text",
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Alt Text", Description = "Alternative text for accessibility" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Alternatif Metin", Description = "Erişilebilirlik için alternatif metin" }
                                    }
                                },
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "url", 
                                    Type = Domain.Common.SectionItemFieldType.URL, 
                                    Placeholder = "/",
                                    DefaultValue = "/",
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Link URL", Description = "Where logo should link to" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Bağlantı URL", Description = "Logonun yönlendireceği adres" }
                                    }
                                }
                            },
                            SectionItems = new List<SectionItemConfiguration>(), // No nested items
                            UIConfiguration = new ItemUIConfiguration
                            {
                                Layout = "list",
                                ShowPreview = true,
                                ShowReorder = false,
                                AddButtonText = "",
                                IconClass = "fa-image"
                            }
                        },
                        // Menu Configuration
                        new SectionItemConfiguration
                            {
                            MinItems = 3,
                            MaxItems = 8,
                                DefaultItemCount = 3,
                                AllowDynamicSectionItems = true,
                                ItemType = Domain.Common.SectionItemType.Menu,
                            Translations = new List<SectionItemTranslationDto>
                            {
                                new SectionItemTranslationDto
                                {
                                    LanguageId = 1033,
                                    Title = "Menu Items",
                                    Description = "Navigation menu items"
                                },
                                new SectionItemTranslationDto
                                {
                                    LanguageId = 1055,
                                    Title = "Menü Öğeleri",
                                    Description = "Navigasyon menü öğeleri"
                                }
                            },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "title", 
                                    Type = Domain.Common.SectionItemFieldType.Title, 
                                    Required = true, 
                                    MaxLength = 50, 
                                    Placeholder = "e.g., Products, Services", 
                                    IsTranslatable = true,
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Menu Title", Description = "Title of the menu item" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Menü Başlığı", Description = "Menü öğesinin başlığı" }
                                    }
                                },
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "icon", 
                                    Type = Domain.Common.SectionItemFieldType.Text, 
                                    Placeholder = "fa fa-bars",
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Icon (Optional)", Description = "FontAwesome icon class" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "İkon (Opsiyonel)", Description = "FontAwesome ikon sınıfı" }
                                    }
                                }
                            },
                            // Nested: Dropdown Links
                            SectionItems = new List<SectionItemConfiguration>
                            {
                                new SectionItemConfiguration
                                {
                                    MinItems = 1,
                                    MaxItems = 10,
                                    DefaultItemCount = 3,
                                    AllowDynamicSectionItems = true,
                                    ItemType = Domain.Common.SectionItemType.Link,
                                    Translations = new List<SectionItemTranslationDto>
                                    {
                                        new SectionItemTranslationDto
                                            {
                                                LanguageId = 1033,
                                            Title = "Dropdown Link",
                                            Description = "Link in dropdown menu"
                                            },
                                        new SectionItemTranslationDto
                                            {
                                                LanguageId = 1055,
                                            Title = "Açılır Menü Linki",
                                            Description = "Açılır menüdeki bağlantı"
                                        }
                                    },
                                    Fields = new List<SectionItemFieldDto>
                                    {
                                        new SectionItemFieldDto 
                                        { 
                                            FieldKey = "title", 
                                            Type = Domain.Common.SectionItemFieldType.Title, 
                                            Required = true, 
                                            MaxLength = 50, 
                                            Placeholder = "e.g., Home, About", 
                                            IsTranslatable = true,
                                            Translations = new List<SectionItemFieldTranslationDto>
                                            {
                                                new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Link Text", Description = "Text for the navigation link" },
                                                new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Link Metni", Description = "Navigasyon linki için metin" }
                                            }
                                        },
                                        new SectionItemFieldDto 
                                        { 
                                            FieldKey = "url", 
                                            Type = Domain.Common.SectionItemFieldType.URL, 
                                            Required = true, 
                                            Placeholder = "/page-url or https://example.com",
                                            Translations = new List<SectionItemFieldTranslationDto>
                                            {
                                                new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "URL", Description = "Link destination" },
                                                new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "URL", Description = "Link hedefi" }
                                            }
                                        },
                                        new SectionItemFieldDto 
                                        { 
                                            FieldKey = "icon", 
                                            Type = Domain.Common.SectionItemFieldType.Text, 
                                            Placeholder = "fa fa-home",
                                            Translations = new List<SectionItemFieldTranslationDto>
                                            {
                                                new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Icon (Optional)", Description = "FontAwesome icon class" },
                                                new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "İkon (Opsiyonel)", Description = "FontAwesome ikon sınıfı" }
                                            }
                                        },
                                        new SectionItemFieldDto 
                                        { 
                                            FieldKey = "openInNewTab", 
                                            Type = Domain.Common.SectionItemFieldType.Checkbox, 
                                            DefaultValue = "false",
                                            Translations = new List<SectionItemFieldTranslationDto>
                                            {
                                                new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Open in New Tab", Description = "Open link in new browser tab" },
                                                new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Yeni Sekmede Aç", Description = "Linki yeni tarayıcı sekmesinde aç" }
                                            }
                                        }
                                    },
                                    SectionItems = new List<SectionItemConfiguration>(), // No deeper nesting
                            UIConfiguration = new ItemUIConfiguration
                            {
                                Layout = "list",
                                ShowPreview = true,
                                ShowReorder = true,
                                AddButtonText = "Add Dropdown Link",
                                IconClass = "fa-link"
                                    }
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
                    },
                    SectionUIConfiguration = new SectionUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = false,
                        AddButtonText = "",
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
                    MinSectionItemCount = 3,
                    MaxSectionItemCount = 6,
                    DefaultSectionCount = 3,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 6,
                    DefaultItemCount = 3,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Menu,
                            Translations = new List<SectionItemTranslationDto>
                            {
                                new SectionItemTranslationDto { LanguageId = 1033, Title = "Mega Menu Category", Description = "Category with featured content" },
                                new SectionItemTranslationDto { LanguageId = 1055, Title = "Mega Menü Kategorisi", Description = "Öne çıkan içerikli kategori" }
                            },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "title", 
                                    Type = Domain.Common.SectionItemFieldType.Title, 
                                    Required = true, 
                                    MaxLength = 50, 
                                    IsTranslatable = true,
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Menu Title", Description = "Title of the menu category" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Menü Başlığı", Description = "Menü kategorisinin başlığı" }
                                    }
                                },
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "description", 
                                    Type = Domain.Common.SectionItemFieldType.Description, 
                                    MaxLength = 200, 
                                    Placeholder = "Brief description for mega menu", 
                                    IsTranslatable = true,
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Description", Description = "Brief category description" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Açıklama", Description = "Kısa kategori açıklaması" }
                                    }
                                },
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "image", 
                                    Type = Domain.Common.SectionItemFieldType.Image,
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Featured Image", Description = "Image for this category" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Öne Çıkan Resim", Description = "Bu kategori için resim" }
                                    }
                                },
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "icon", 
                                    Type = Domain.Common.SectionItemFieldType.Icon, 
                                    Placeholder = "fa fa-star",
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Icon", Description = "Category icon" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "İkon", Description = "Kategori ikonu" }
                                    }
                                }
                            },
                            SectionItems = new List<SectionItemConfiguration>
                            {
                                new SectionItemConfiguration
                    {
                        MinItems = 2,
                        MaxItems = 15,
                        DefaultItemCount = 3,
                                    AllowDynamicSectionItems = true,
                        ItemType = Domain.Common.SectionItemType.Link,
                                    Translations = new List<SectionItemTranslationDto>
                                    {
                                        new SectionItemTranslationDto { LanguageId = 1033, Title = "Mega Menu Link", Description = "Link within mega menu" },
                                        new SectionItemTranslationDto { LanguageId = 1055, Title = "Mega Menü Linki", Description = "Mega menü içindeki link" }
                                    },
                                    Fields = new List<SectionItemFieldDto>
                                    {
                                        new SectionItemFieldDto 
                                        { 
                                            FieldKey = "title", 
                                            Type = Domain.Common.SectionItemFieldType.Title, 
                                            Required = true, 
                                            MaxLength = 50, 
                                            IsTranslatable = true,
                                            Translations = new List<SectionItemFieldTranslationDto>
                                            {
                                                new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Link Text", Description = "Text for the link" },
                                                new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Link Metni", Description = "Link için metin" }
                                            }
                                        },
                                        new SectionItemFieldDto 
                                        { 
                                            FieldKey = "url", 
                                            Type = Domain.Common.SectionItemFieldType.URL, 
                                            Required = true,
                                            Translations = new List<SectionItemFieldTranslationDto>
                                            {
                                                new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "URL", Description = "Link destination" },
                                                new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "URL", Description = "Link hedefi" }
                                            }
                                        },
                                        new SectionItemFieldDto 
                                        { 
                                            FieldKey = "description", 
                                            Type = Domain.Common.SectionItemFieldType.Description, 
                                            MaxLength = 100, 
                                            IsTranslatable = true,
                                            Translations = new List<SectionItemFieldTranslationDto>
                                            {
                                                new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Description", Description = "Link description" },
                                                new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Açıklama", Description = "Link açıklaması" }
                                            }
                                        },
                                        new SectionItemFieldDto 
                                        { 
                                            FieldKey = "icon", 
                                            Type = Domain.Common.SectionItemFieldType.Icon, 
                                            Placeholder = "fa fa-chevron-right",
                                            Translations = new List<SectionItemFieldTranslationDto>
                                            {
                                                new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Icon", Description = "Link icon" },
                                                new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "İkon", Description = "Link ikonu" }
                                            }
                                        }
                                    },
                                    SectionItems = new List<SectionItemConfiguration>(),
                        UIConfiguration = new ItemUIConfiguration
                        {
                            Layout = "list",
                            ShowPreview = true,
                            ShowReorder = true,
                            AddButtonText = "Add Mega Menu Link",
                            IconClass = "fa-link"
                                    }
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
                    },
                    SectionUIConfiguration = new SectionUIConfiguration
                    {
                        Layout = "grid",
                        Columns = 2,
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Menu Item",
                        IconClass = "fa-bars"
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
                    MinSectionItemCount = 3,
                    MaxSectionItemCount = 6,
                    DefaultSectionCount = 4,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 6,
                    DefaultItemCount = 4,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Menu,
                            Translations = new List<SectionItemTranslationDto>
                            {
                                new SectionItemTranslationDto { LanguageId = 1033, Title = "Service Tab", Description = "Tab with service information" },
                                new SectionItemTranslationDto { LanguageId = 1055, Title = "Hizmet Sekmesi", Description = "Hizmet bilgisi içeren sekme" }
                            },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "title", 
                                    Type = Domain.Common.SectionItemFieldType.Title, 
                                    Required = true, 
                                    MaxLength = 50, 
                                    IsTranslatable = true,
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Tab Title", Description = "Title of the service tab" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Sekme Başlığı", Description = "Hizmet sekmesinin başlığı" }
                                    }
                                },
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "description", 
                                    Type = Domain.Common.SectionItemFieldType.Description, 
                                    Required = true, 
                                    MaxLength = 500, 
                                    IsTranslatable = true,
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Content", Description = "Tab content/description" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "İçerik", Description = "Sekme içeriği/açıklaması" }
                                    }
                                },
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "url", 
                                    Type = Domain.Common.SectionItemFieldType.URL,
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Link URL", Description = "Optional link for this tab" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Link URL", Description = "Bu sekme için opsiyonel link" }
                                    }
                                },
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "icon", 
                                    Type = Domain.Common.SectionItemFieldType.Icon, 
                                    Required = true, 
                                    Placeholder = "fa fa-cog",
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Tab Icon", Description = "Icon for this service tab" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Sekme İkonu", Description = "Bu hizmet sekmesi için ikon" }
                                    }
                                }
                            },
                            SectionItems = new List<SectionItemConfiguration>(),
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Service Tab",
                                IconClass = "fa-folder-open"
                            }
                        }
                    },
                    SectionUIConfiguration = new SectionUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Tab",
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
                    MinSectionItemCount = 3,
                    MaxSectionItemCount = 8,
                    DefaultSectionCount = 3,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 8,
                    DefaultItemCount = 3,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Menu,
                            Translations = new List<SectionItemTranslationDto>
                            {
                                new SectionItemTranslationDto { LanguageId = 1033, Title = "Category", Description = "Menu category with items" },
                                new SectionItemTranslationDto { LanguageId = 1055, Title = "Kategori", Description = "Öğeler içeren menü kategorisi" }
                            },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "title", 
                                    Type = Domain.Common.SectionItemFieldType.Title, 
                                    Required = true, 
                                    MaxLength = 50, 
                                    IsTranslatable = true,
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Category Title", Description = "Title of the category" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Kategori Başlığı", Description = "Kategorinin başlığı" }
                                    }
                                },
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "icon", 
                                    Type = Domain.Common.SectionItemFieldType.Icon, 
                                    Placeholder = "fa fa-tag",
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Icon", Description = "Category icon" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "İkon", Description = "Kategori ikonu" }
                                    }
                                }
                            },
                            SectionItems = new List<SectionItemConfiguration>
                            {
                                new SectionItemConfiguration
                    {
                        MinItems = 1,
                        MaxItems = 12,
                        DefaultItemCount = 3,
                                    AllowDynamicSectionItems = true,
                        ItemType = Domain.Common.SectionItemType.Link,
                                    Translations = new List<SectionItemTranslationDto>
                                    {
                                        new SectionItemTranslationDto { LanguageId = 1033, Title = "Category Item", Description = "Link within category" },
                                        new SectionItemTranslationDto { LanguageId = 1055, Title = "Kategori Öğesi", Description = "Kategori içindeki link" }
                                    },
                                    Fields = new List<SectionItemFieldDto>
                                    {
                                        new SectionItemFieldDto 
                                        { 
                                            FieldKey = "title", 
                                            Type = Domain.Common.SectionItemFieldType.Title, 
                                            Required = true, 
                                            MaxLength = 50, 
                                            IsTranslatable = true,
                                            Translations = new List<SectionItemFieldTranslationDto>
                                            {
                                                new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Item Title", Description = "Title of the item" },
                                                new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Öğe Başlığı", Description = "Öğenin başlığı" }
                                            }
                                        },
                                        new SectionItemFieldDto 
                                        { 
                                            FieldKey = "url", 
                                            Type = Domain.Common.SectionItemFieldType.URL, 
                                            Required = true,
                                            Translations = new List<SectionItemFieldTranslationDto>
                                            {
                                                new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "URL", Description = "Link destination" },
                                                new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "URL", Description = "Link hedefi" }
                                            }
                                        },
                                        new SectionItemFieldDto 
                                        { 
                                            FieldKey = "icon", 
                                            Type = Domain.Common.SectionItemFieldType.Icon, 
                                            Placeholder = "fa fa-chevron-right",
                                            Translations = new List<SectionItemFieldTranslationDto>
                                            {
                                                new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Icon", Description = "Item icon" },
                                                new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "İkon", Description = "Öğe ikonu" }
                                            }
                                        }
                                    },
                                    SectionItems = new List<SectionItemConfiguration>(),
                        UIConfiguration = new ItemUIConfiguration
                        {
                            Layout = "list",
                            ShowPreview = true,
                            ShowReorder = true,
                            AddButtonText = "Add Category Link",
                            IconClass = "fa-link"
                                    }
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
                    },
                    SectionUIConfiguration = new SectionUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Menu Category",
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
                    MinSectionItemCount = 1,
                    MaxSectionItemCount = null, // Unlimited
                    DefaultSectionCount = 3,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 1,
                            MaxItems = null,
                    DefaultItemCount = 3,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                            Translations = new List<SectionItemTranslationDto>
                            {
                                new SectionItemTranslationDto { LanguageId = 1033, Title = "Content Item", Description = "General content item" },
                                new SectionItemTranslationDto { LanguageId = 1055, Title = "İçerik Öğesi", Description = "Genel içerik öğesi" }
                            },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "title", 
                                    Type = Domain.Common.SectionItemFieldType.Title, 
                                    Required = true, 
                                    MaxLength = 100, 
                                    IsTranslatable = true,
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Title", Description = "Item title" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Başlık", Description = "Öğe başlığı" }
                                    }
                                },
                                new SectionItemFieldDto 
                                { 
                                    FieldKey = "description", 
                                    Type = Domain.Common.SectionItemFieldType.Description, 
                                    MaxLength = 500, 
                                    IsTranslatable = true,
                                    Translations = new List<SectionItemFieldTranslationDto>
                                    {
                                        new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Description", Description = "Item description" },
                                        new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Açıklama", Description = "Öğe açıklaması" }
                                    }
                                }
                            },
                            SectionItems = new List<SectionItemConfiguration>(),
                    UIConfiguration = new ItemUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Item"
                            }
                        }
                    },
                    SectionUIConfiguration = new SectionUIConfiguration
                    {
                        Layout = "list",
                        ShowPreview = true,
                        ShowReorder = true,
                        AddButtonText = "Add Section Item"
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
                    MinSectionItemCount = 3,
                    MaxSectionItemCount = 10,
                    DefaultSectionCount = 5,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 10,
                    DefaultItemCount = 5,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Image,
                    MediaType = Domain.Common.MediaType.Image,
                            Translations = new List<SectionItemTranslationDto>
                            {
                                new SectionItemTranslationDto { LanguageId = 1033, Title = "Slide", Description = "Carousel slide" },
                                new SectionItemTranslationDto { LanguageId = 1055, Title = "Slayt", Description = "Carousel slaytı" }
                            },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto { FieldKey = "image", Type = Domain.Common.SectionItemFieldType.Image, Required = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Slide Image" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Slayt Resmi" } } },
                                new SectionItemFieldDto { FieldKey = "title", Type = Domain.Common.SectionItemFieldType.Title, MaxLength = 100, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Slide Title" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Slayt Başlığı" } } },
                                new SectionItemFieldDto { FieldKey = "description", Type = Domain.Common.SectionItemFieldType.Description, MaxLength = 300, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Slide Description" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Slayt Açıklaması" } } },
                                new SectionItemFieldDto { FieldKey = "buttonText", Type = Domain.Common.SectionItemFieldType.Text, MaxLength = 50, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Button Text" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Buton Metni" } } },
                                new SectionItemFieldDto { FieldKey = "buttonUrl", Type = Domain.Common.SectionItemFieldType.URL, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Button URL" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Buton URL" } } }
                            },
                            SectionItems = new List<SectionItemConfiguration>(),
                            UIConfiguration = new ItemUIConfiguration { Layout = "grid", Columns = 3, ShowPreview = true, ShowReorder = true, AddButtonText = "Add Slide", IconClass = "fa-images" }
                        }
                    },
                    SectionUIConfiguration = new SectionUIConfiguration { Layout = "grid", Columns = 3, ShowPreview = true, ShowReorder = true, AddButtonText = "Add Slide", IconClass = "fa-images" }
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
                    MinSectionItemCount = 3,
                    MaxSectionItemCount = 12,
                    DefaultSectionCount = 6,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 12,
                    DefaultItemCount = 6,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                            Translations = new List<SectionItemTranslationDto>
                            {
                                new SectionItemTranslationDto { LanguageId = 1033, Title = "Grid Item", Description = "Item in grid layout" },
                                new SectionItemTranslationDto { LanguageId = 1055, Title = "Grid Öğesi", Description = "Grid düzenindeki öğe" }
                            },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto { FieldKey = "image", Type = Domain.Common.SectionItemFieldType.Image, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Image" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Resim" } } },
                                new SectionItemFieldDto { FieldKey = "title", Type = Domain.Common.SectionItemFieldType.Text, Required = true, MaxLength = 100, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Title" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Başlık" } } },
                                new SectionItemFieldDto { FieldKey = "description", Type = Domain.Common.SectionItemFieldType.Description, MaxLength = 300, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Description" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Açıklama" } } },
                                new SectionItemFieldDto { FieldKey = "url", Type = Domain.Common.SectionItemFieldType.URL, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Link URL" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Link URL" } } }
                            },
                            SectionItems = new List<SectionItemConfiguration>(),
                            UIConfiguration = new ItemUIConfiguration { Layout = "grid", Columns = 3, ShowPreview = true, ShowReorder = true, AddButtonText = "Add Grid Item" }
                        }
                    },
                    SectionUIConfiguration = new SectionUIConfiguration { Layout = "grid", Columns = 3, ShowPreview = true, ShowReorder = true, AddButtonText = "Add Grid Item" }
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
                    MinSectionItemCount = 4,
                    MaxSectionItemCount = 20,
                    DefaultSectionCount = 8,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 4,
                    MaxItems = 20,
                    DefaultItemCount = 8,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Image,
                    MediaType = Domain.Common.MediaType.Image,
                            Translations = new List<SectionItemTranslationDto> { new SectionItemTranslationDto { LanguageId = 1033, Title = "Image", Description = "Masonry image item" }, new SectionItemTranslationDto { LanguageId = 1055, Title = "Resim", Description = "Masonry resim öğesi" } },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto { FieldKey = "image", Type = Domain.Common.SectionItemFieldType.Image, Required = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Image" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Resim" } } },
                                new SectionItemFieldDto { FieldKey = "title", Type = Domain.Common.SectionItemFieldType.Title, MaxLength = 100, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Title" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Başlık" } } },
                                new SectionItemFieldDto { FieldKey = "description", Type = Domain.Common.SectionItemFieldType.Description, MaxLength = 200, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Caption" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Altyazı" } } }
                            },
                            SectionItems = new List<SectionItemConfiguration>(),
                            UIConfiguration = new ItemUIConfiguration { Layout = "grid", Columns = 4, ShowPreview = true, ShowReorder = true, AddButtonText = "Add Image" }
                        }
                    },
                    SectionUIConfiguration = new SectionUIConfiguration { Layout = "grid", Columns = 4, ShowPreview = true, ShowReorder = true, AddButtonText = "Add Image" }
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
                    MinSectionItemCount = 2,
                    MaxSectionItemCount = 10,
                    DefaultSectionCount = 4,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 2,
                    MaxItems = 10,
                    DefaultItemCount = 4,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                            Translations = new List<SectionItemTranslationDto> { new SectionItemTranslationDto { LanguageId = 1033, Title = "Step", Description = "Sequential step" }, new SectionItemTranslationDto { LanguageId = 1055, Title = "Adım", Description = "Sıralı adım" } },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto { FieldKey = "title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 100, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Step Title" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Adım Başlığı" } } },
                                new SectionItemFieldDto { FieldKey = "description", Type = Domain.Common.SectionItemFieldType.Description, Required = true, MaxLength = 500, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Step Description" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Adım Açıklaması" } } },
                                new SectionItemFieldDto { FieldKey = "icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-check", Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Step Icon" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Adım İkonu" } } }
                            },
                            SectionItems = new List<SectionItemConfiguration>(),
                            UIConfiguration = new ItemUIConfiguration { Layout = "list", ShowPreview = true, ShowReorder = true, AddButtonText = "Add Step" }
                        }
                    },
                    SectionUIConfiguration = new SectionUIConfiguration { Layout = "list", ShowPreview = true, ShowReorder = true, AddButtonText = "Add Step" }
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
                    MinSectionItemCount = 3,
                    MaxSectionItemCount = 15,
                    DefaultSectionCount = 5,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 15,
                    DefaultItemCount = 5,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                            Translations = new List<SectionItemTranslationDto> { new SectionItemTranslationDto { LanguageId = 1033, Title = "List Item", Description = "Item in list" }, new SectionItemTranslationDto { LanguageId = 1055, Title = "Liste Öğesi", Description = "Listedeki öğe" } },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto { FieldKey = "title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 200, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Item Text" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Öğe Metni" } } },
                                new SectionItemFieldDto { FieldKey = "icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-check-circle", Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Icon" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "İkon" } } },
                                new SectionItemFieldDto { FieldKey = "url", Type = Domain.Common.SectionItemFieldType.URL, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Link (Optional)" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Link (Opsiyonel)" } } }
                            },
                            SectionItems = new List<SectionItemConfiguration>(),
                            UIConfiguration = new ItemUIConfiguration { Layout = "list", ShowPreview = true, ShowReorder = true, AddButtonText = "Add List Item" }
                        }
                    },
                    SectionUIConfiguration = new SectionUIConfiguration { Layout = "list", ShowPreview = true, ShowReorder = true, AddButtonText = "Add List Item" }
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
                    MinSectionItemCount = 1,
                    MaxSectionItemCount = 1,
                    DefaultSectionCount = 1,
                    AllowDynamicSectionItems = false,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 1,
                    MaxItems = 1,
                    DefaultItemCount = 1,
                            AllowDynamicSectionItems = false,
                    ItemType = Domain.Common.SectionItemType.Text,
                            Translations = new List<SectionItemTranslationDto> { new SectionItemTranslationDto { LanguageId = 1033, Title = "Single Item", Description = "Featured single item" }, new SectionItemTranslationDto { LanguageId = 1055, Title = "Tek Öğe", Description = "Öne çıkan tek öğe" } },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto { FieldKey = "image", Type = Domain.Common.SectionItemFieldType.Image, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Featured Image" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Öne Çıkan Resim" } } },
                                new SectionItemFieldDto { FieldKey = "title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 150, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Title" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Başlık" } } },
                                new SectionItemFieldDto { FieldKey = "description", Type = Domain.Common.SectionItemFieldType.Description, Required = true, MaxLength = 1000, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Description" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Açıklama" } } },
                                new SectionItemFieldDto { FieldKey = "buttonText", Type = Domain.Common.SectionItemFieldType.Text, MaxLength = 50, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Button Text" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Buton Metni" } } },
                                new SectionItemFieldDto { FieldKey = "buttonUrl", Type = Domain.Common.SectionItemFieldType.URL, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Button URL" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Buton URL" } } }
                            },
                            SectionItems = new List<SectionItemConfiguration>(),
                            UIConfiguration = new ItemUIConfiguration { Layout = "list", ShowPreview = true, ShowReorder = false, AddButtonText = "" }
                        }
                    },
                    SectionUIConfiguration = new SectionUIConfiguration { Layout = "list", ShowPreview = true, ShowReorder = false, AddButtonText = "" }
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
                    MinSectionItemCount = 2,
                    MaxSectionItemCount = 8,
                    DefaultSectionCount = 4,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 2,
                    MaxItems = 8,
                    DefaultItemCount = 4,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                            Translations = new List<SectionItemTranslationDto> { new SectionItemTranslationDto { LanguageId = 1033, Title = "Item", Description = "Multi item" }, new SectionItemTranslationDto { LanguageId = 1055, Title = "Öğe", Description = "Çoklu öğe" } },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto { FieldKey = "image", Type = Domain.Common.SectionItemFieldType.Image, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Image" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Resim" } } },
                                new SectionItemFieldDto { FieldKey = "title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 100, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Title" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Başlık" } } },
                                new SectionItemFieldDto { FieldKey = "description", Type = Domain.Common.SectionItemFieldType.Description, MaxLength = 300, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Description" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Açıklama" } } },
                                new SectionItemFieldDto { FieldKey = "url", Type = Domain.Common.SectionItemFieldType.URL, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Link" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Link" } } }
                            },
                            SectionItems = new List<SectionItemConfiguration>(),
                            UIConfiguration = new ItemUIConfiguration { Layout = "grid", Columns = 2, ShowPreview = true, ShowReorder = true, AddButtonText = "Add Item" }
                        }
                    },
                    SectionUIConfiguration = new SectionUIConfiguration { Layout = "grid", Columns = 2, ShowPreview = true, ShowReorder = true, AddButtonText = "Add Item" }
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
                    MinSectionItemCount = 3,
                    MaxSectionItemCount = 10,
                    DefaultSectionCount = 5,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 3,
                    MaxItems = 10,
                    DefaultItemCount = 5,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                            Translations = new List<SectionItemTranslationDto> { new SectionItemTranslationDto { LanguageId = 1033, Title = "Panel", Description = "Accordion panel" }, new SectionItemTranslationDto { LanguageId = 1055, Title = "Panel", Description = "Accordion paneli" } },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto { FieldKey = "title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 150, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Panel Title" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Panel Başlığı" } } },
                                new SectionItemFieldDto { FieldKey = "description", Type = Domain.Common.SectionItemFieldType.Description, Required = true, MaxLength = 1000, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Panel Content" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Panel İçeriği" } } },
                                new SectionItemFieldDto { FieldKey = "icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-question-circle", Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Icon" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "İkon" } } }
                            },
                            SectionItems = new List<SectionItemConfiguration>(),
                            UIConfiguration = new ItemUIConfiguration { Layout = "list", ShowPreview = true, ShowReorder = true, AddButtonText = "Add Panel" }
                        }
                    },
                    SectionUIConfiguration = new SectionUIConfiguration { Layout = "list", ShowPreview = true, ShowReorder = true, AddButtonText = "Add Panel" }
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
                    MinSectionItemCount = 2,
                    MaxSectionItemCount = 8,
                    DefaultSectionCount = 4,
                    AllowDynamicSectionItems = true,
                    SectionItems = new List<SectionItemConfiguration>
                    {
                        new SectionItemConfiguration
                {
                    MinItems = 2,
                    MaxItems = 8,
                    DefaultItemCount = 4,
                            AllowDynamicSectionItems = true,
                    ItemType = Domain.Common.SectionItemType.Text,
                            Translations = new List<SectionItemTranslationDto> { new SectionItemTranslationDto { LanguageId = 1033, Title = "Tab", Description = "Tab item" }, new SectionItemTranslationDto { LanguageId = 1055, Title = "Sekme", Description = "Sekme öğesi" } },
                            Fields = new List<SectionItemFieldDto>
                            {
                                new SectionItemFieldDto { FieldKey = "title", Type = Domain.Common.SectionItemFieldType.Title, Required = true, MaxLength = 50, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Tab Title" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Sekme Başlığı" } } },
                                new SectionItemFieldDto { FieldKey = "description", Type = Domain.Common.SectionItemFieldType.Description, Required = true, MaxLength = 1000, IsTranslatable = true, Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Tab Content" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Sekme İçeriği" } } },
                                new SectionItemFieldDto { FieldKey = "icon", Type = Domain.Common.SectionItemFieldType.Icon, Placeholder = "fa fa-star", Translations = new List<SectionItemFieldTranslationDto> { new SectionItemFieldTranslationDto { LanguageId = 1033, Label = "Tab Icon" }, new SectionItemFieldTranslationDto { LanguageId = 1055, Label = "Sekme İkonu" } } }
                            },
                            SectionItems = new List<SectionItemConfiguration>(),
                            UIConfiguration = new ItemUIConfiguration { Layout = "list", ShowPreview = true, ShowReorder = true, AddButtonText = "Add Tab" }
                        }
                    },
                    SectionUIConfiguration = new SectionUIConfiguration { Layout = "list", ShowPreview = true, ShowReorder = true, AddButtonText = "Add Tab" }
                }
            };
        }

        #endregion
    }
}
