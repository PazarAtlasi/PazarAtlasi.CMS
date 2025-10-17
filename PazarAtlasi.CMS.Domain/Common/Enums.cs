using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Common
{
    public enum ThemeType
    {
        None,
        Light,
        Dark,
        Colorful,
        Minimalistic,
        Modern,
        Classic,
        Professional,
        Creative,
        Elegant
    }

    public enum  SectionItemFieldType
    {
        None,
        Text,
        Title,
        Description,
        TextArea,
        Checkbox,
        Paragraph,
        Number,
        RichText,
        Date,
        Boolean,
        Image,
        Video,
        URL,
        Dropdown,
        MultiSelect,
        Color,
        Icon,
        FileUpload
    }

    public enum SectionItemType
    {
        None,
        FeatureCard,
        Dropdown,
        List,
        Button,
        Text,
        Link,
        PageRedirect,
        Paragraph,
        Image,
        Video,
        Gallery,
        Document,
        Map,
        Form,
        Grid,
        Sidebar,
        Search,
        ContactForm,
        SocialMediaLinks,
        Menu,
        Media
    }

    public enum TemplateType
    {
        None,
        Default,
        Sequential,
        Grid,
        Masonry,
        Carousel,
        List,
        SingleItem,
        MultiItem,
        Accordion,
        Tabs,
        MegaMenu
    }

    public enum Status
    {
        Draft = 0,
        Active = 1,
        Deleted = -99,
        Archived = 3,
        Pending = 4
    }

    public enum EntityType
    {
        None,
        Content,
        Page,
        Article,
        Product,
        Catalog,
        Category,
        Brand,
        Tag,
        Blog,
        Document,
        User
    }

    public enum PageType
    {
        None,
        Home,
        Article,
        Product,
        Catalog,
        Category,
        Brand,
        Tag,
        Blog,
        Document,
        UserProfile,
    }

    public enum SectionType
    {
        None,
        Navbar,
        Header,
        Hero,
        Catalog,
        Favorite,
        Featured,
        Newsletter,
        ContentBlock,
        Contact,
        Footer,
        Sidebar,
        MainContent,
        RelatedContent,
        Advertisement,
        Search,
        ContactForm,
        WhyUs,
        SocialMediaLinks,
        Testimonials,
        CallToAction,
        Breadcrumbs,
        Pagination,
        Map,
        Gallery
    }

    public enum MediaType
    {
        None,
        Image,
        Video,
        ImageSlider,
        Audio,
        Document
    }
}
