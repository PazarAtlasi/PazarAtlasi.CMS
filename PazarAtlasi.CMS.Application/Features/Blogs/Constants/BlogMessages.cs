namespace PazarAtlasi.CMS.Application.Features.Blogs.Constants
{
    public static class BlogMessages
    {
        // Success messages
        public const string BlogCreated = "Blog başarıyla oluşturuldu.";
        public const string BlogUpdated = "Blog başarıyla güncellendi.";
        public const string BlogDeleted = "Blog başarıyla silindi.";
        
        // Error messages
        public const string BlogNotFound = "Blog bulunamadı.";
        public const string BlogTitleExists = "Bu başlıkta bir blog zaten var.";
        public const string BlogSlugExists = "Bu URL ile bir blog zaten var.";
        public const string InvalidTitle = "Geçersiz blog başlığı.";
        public const string InvalidContent = "Blog içeriği boş olamaz.";
        public const string CategoryNotFound = "Kategori bulunamadı.";
        public const string AuthorNotFound = "Yazar bulunamadı.";
        public const string TagNotFound = "Etiket bulunamadı.";
    }
} 