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

    public enum SectionItemFieldType
    {
        None,
        Text,
        TextArea,
        Title,
        Description,
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
        Logo,
        Container,
        Tab,
        Category,
        ServiceCard,
        SubCategory,
        BlogPost,
        ContactInfo,
        CategoryLink,
        PromoLink,
        Service,
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
        Page,
        Category,
        Product,
        Brand,
        Tag,
        Blog,
        Document,
        Article,
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

    public enum ProductType
    {
        None,
        Simple,
        Variable,
        Grouped,
        External,
        Digital,
        Service,
        Bundle
    }

    public enum OptionType
    {
        None,
        Text,
        Number,
        Color,
        Size,
        Material,
        Dropdown,
        Checkbox,
        Radio,
        Date,
        Boolean,
        Image,
        File
    }
}
