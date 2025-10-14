using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Common
{
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

    public enum SectionItemType
    {
        None,
        Text,
        Image,
        Paragraph,
        Link,
        Button,
        Gallery,
        Audio,
        Pdf,
        Picture,
        Video,
        Document,
        Map,
        Form,
        List,
        Grid,
        Sidebar,
        Advertisement,
        Search,
        ContactForm,
        SocialMediaLinks,
        Testimonials,
        CallToAction,
        Breadcrumbs,
        Pagination
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
