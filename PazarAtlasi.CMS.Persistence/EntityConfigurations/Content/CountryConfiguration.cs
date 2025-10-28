using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries").HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Code).HasColumnName("Code").HasMaxLength(10);
            builder.Property(c => c.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
            builder.Property(c => c.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(c => c.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(c => c.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(c => c.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(c => c.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(c => c.UpdatedBy).HasColumnName("UpdatedBy");

            // Indexes
            builder.HasIndex(c => c.Code).HasDatabaseName("IX_Countries_Code");
            builder.HasIndex(c => c.IsActive).HasDatabaseName("IX_Countries_IsActive");
            builder.HasIndex(c => c.SortOrder).HasDatabaseName("IX_Countries_SortOrder");

            // Query Filter
            builder.HasQueryFilter(c => !c.IsDeleted);

            // Seed Data - Mock countries from the provided HTML
            var countries = new[]
            {
                // Afrika
                new { Id = 1, Name = "Mısır", Code = "EG", SortOrder = 1 },
                new { Id = 2, Name = "Gabon", Code = "GA", SortOrder = 2 },
                new { Id = 3, Name = "Gana", Code = "GH", SortOrder = 3 },
                new { Id = 4, Name = "Etiyopya", Code = "ET", SortOrder = 4 },
                new { Id = 5, Name = "Kenya", Code = "KE", SortOrder = 5 },
                new { Id = 6, Name = "Tanzanya", Code = "TZ", SortOrder = 6 },
                new { Id = 7, Name = "Güney Afrika", Code = "ZA", SortOrder = 7 },
                new { Id = 8, Name = "Nijerya", Code = "NG", SortOrder = 8 },
                new { Id = 9, Name = "Senegal", Code = "SN", SortOrder = 9 },
                new { Id = 10, Name = "Fas", Code = "MA", SortOrder = 10 },
                new { Id = 11, Name = "Tunus", Code = "TN", SortOrder = 11 },
                new { Id = 12, Name = "Cezayir", Code = "DZ", SortOrder = 12 },
                new { Id = 13, Name = "Uganda", Code = "UG", SortOrder = 13 },
                new { Id = 14, Name = "Ruanda", Code = "RW", SortOrder = 14 },
                new { Id = 15, Name = "Kamerun", Code = "CM", SortOrder = 15 },
                
                // Avrupa
                new { Id = 16, Name = "Almanya", Code = "DE", SortOrder = 16 },
                new { Id = 17, Name = "Fransa", Code = "FR", SortOrder = 17 },
                new { Id = 18, Name = "İngiltere", Code = "GB", SortOrder = 18 },
                new { Id = 19, Name = "İtalya", Code = "IT", SortOrder = 19 },
                new { Id = 20, Name = "İspanya", Code = "ES", SortOrder = 20 },
                new { Id = 21, Name = "Hollanda", Code = "NL", SortOrder = 21 },
                new { Id = 22, Name = "Belçika", Code = "BE", SortOrder = 22 },
                new { Id = 23, Name = "Polonya", Code = "PL", SortOrder = 23 },
                new { Id = 24, Name = "Romanya", Code = "RO", SortOrder = 24 },
                new { Id = 25, Name = "Yunanistan", Code = "GR", SortOrder = 25 },
                new { Id = 26, Name = "Portekiz", Code = "PT", SortOrder = 26 },
                new { Id = 27, Name = "Avusturya", Code = "AT", SortOrder = 27 },
                new { Id = 28, Name = "İsviçre", Code = "CH", SortOrder = 28 },
                new { Id = 29, Name = "İsveç", Code = "SE", SortOrder = 29 },
                new { Id = 30, Name = "Norveç", Code = "NO", SortOrder = 30 },
                new { Id = 31, Name = "Danimarka", Code = "DK", SortOrder = 31 },
                new { Id = 32, Name = "Finlandiya", Code = "FI", SortOrder = 32 },
                new { Id = 33, Name = "Çek Cumhuriyeti", Code = "CZ", SortOrder = 33 },
                new { Id = 34, Name = "Macaristan", Code = "HU", SortOrder = 34 },
                new { Id = 35, Name = "Bulgaristan", Code = "BG", SortOrder = 35 },
                new { Id = 36, Name = "Hırvatistan", Code = "HR", SortOrder = 36 },
                new { Id = 37, Name = "Slovakya", Code = "SK", SortOrder = 37 },
                new { Id = 38, Name = "Slovenya", Code = "SI", SortOrder = 38 },
                new { Id = 39, Name = "Litvanya", Code = "LT", SortOrder = 39 },
                new { Id = 40, Name = "Letonya", Code = "LV", SortOrder = 40 },
                new { Id = 41, Name = "Estonya", Code = "EE", SortOrder = 41 },
                
                // Amerika
                new { Id = 42, Name = "Amerika Birleşik Devletleri", Code = "US", SortOrder = 42 },
                new { Id = 43, Name = "Kanada", Code = "CA", SortOrder = 43 },
                new { Id = 44, Name = "Meksika", Code = "MX", SortOrder = 44 },
                new { Id = 45, Name = "Brezilya", Code = "BR", SortOrder = 45 },
                new { Id = 46, Name = "Arjantin", Code = "AR", SortOrder = 46 },
                new { Id = 47, Name = "Şili", Code = "CL", SortOrder = 47 },
                new { Id = 48, Name = "Kolombiya", Code = "CO", SortOrder = 48 },
                new { Id = 49, Name = "Peru", Code = "PE", SortOrder = 49 },
                new { Id = 50, Name = "Venezuela", Code = "VE", SortOrder = 50 },
                new { Id = 51, Name = "Ekvador", Code = "EC", SortOrder = 51 },
                new { Id = 52, Name = "Uruguay", Code = "UY", SortOrder = 52 },
                new { Id = 53, Name = "Paraguay", Code = "PY", SortOrder = 53 },
                new { Id = 54, Name = "Bolivya", Code = "BO", SortOrder = 54 },
                
                // Asya
                new { Id = 55, Name = "Çin", Code = "CN", SortOrder = 55 },
                new { Id = 56, Name = "Japonya", Code = "JP", SortOrder = 56 },
                new { Id = 57, Name = "Güney Kore", Code = "KR", SortOrder = 57 },
                new { Id = 58, Name = "Hindistan", Code = "IN", SortOrder = 58 },
                new { Id = 59, Name = "Pakistan", Code = "PK", SortOrder = 59 },
                new { Id = 60, Name = "Bangladeş", Code = "BD", SortOrder = 60 },
                new { Id = 61, Name = "Endonezya", Code = "ID", SortOrder = 61 },
                new { Id = 62, Name = "Filipinler", Code = "PH", SortOrder = 62 },
                new { Id = 63, Name = "Vietnam", Code = "VN", SortOrder = 63 },
                new { Id = 64, Name = "Tayland", Code = "TH", SortOrder = 64 },
                new { Id = 65, Name = "Malezya", Code = "MY", SortOrder = 65 },
                new { Id = 66, Name = "Singapur", Code = "SG", SortOrder = 66 },
                new { Id = 67, Name = "Myanmar", Code = "MM", SortOrder = 67 },
                new { Id = 68, Name = "Kamboçya", Code = "KH", SortOrder = 68 },
                new { Id = 69, Name = "Laos", Code = "LA", SortOrder = 69 },
                new { Id = 70, Name = "Sri Lanka", Code = "LK", SortOrder = 70 },
                new { Id = 71, Name = "Nepal", Code = "NP", SortOrder = 71 },
                
                // Okyanusya
                new { Id = 72, Name = "Avustralya", Code = "AU", SortOrder = 72 },
                new { Id = 73, Name = "Yeni Zelanda", Code = "NZ", SortOrder = 73 },
                
                // Diğer
                new { Id = 74, Name = "Rusya", Code = "RU", SortOrder = 74 },
                new { Id = 75, Name = "Ukrayna", Code = "UA", SortOrder = 75 },
                new { Id = 76, Name = "Kazakistan", Code = "KZ", SortOrder = 76 },
                new { Id = 77, Name = "Özbekistan", Code = "UZ", SortOrder = 77 },
                new { Id = 78, Name = "Türkmenistan", Code = "TM", SortOrder = 78 },
                new { Id = 79, Name = "Kırgızistan", Code = "KG", SortOrder = 79 },
                new { Id = 80, Name = "Tacikistan", Code = "TJ", SortOrder = 80 },
                new { Id = 81, Name = "Azerbaycan", Code = "AZ", SortOrder = 81 },
                new { Id = 82, Name = "Gürcistan", Code = "GE", SortOrder = 82 },
                new { Id = 83, Name = "Ermenistan", Code = "AM", SortOrder = 83 },
                
                // Orta Doğu
                new { Id = 84, Name = "İran", Code = "IR", SortOrder = 84 },
                new { Id = 85, Name = "Irak", Code = "IQ", SortOrder = 85 },
                new { Id = 86, Name = "Suriye", Code = "SY", SortOrder = 86 },
                new { Id = 87, Name = "Ürdün", Code = "JO", SortOrder = 87 },
                new { Id = 88, Name = "Lübnan", Code = "LB", SortOrder = 88 },
                new { Id = 89, Name = "İsrail", Code = "IL", SortOrder = 89 },
                new { Id = 90, Name = "Suudi Arabistan", Code = "SA", SortOrder = 90 },
                new { Id = 91, Name = "Birleşik Arap Emirlikleri", Code = "AE", SortOrder = 91 },
                new { Id = 92, Name = "Kuveyt", Code = "KW", SortOrder = 92 },
                new { Id = 93, Name = "Katar", Code = "QA", SortOrder = 93 },
                new { Id = 94, Name = "Bahreyn", Code = "BH", SortOrder = 94 },
                new { Id = 95, Name = "Umman", Code = "OM", SortOrder = 95 },
                new { Id = 96, Name = "Yemen", Code = "YE", SortOrder = 96 },
                new { Id = 97, Name = "Afganistan", Code = "AF", SortOrder = 97 },
                new { Id = 98, Name = "Libya", Code = "LY", SortOrder = 98 },
                new { Id = 99, Name = "Sudan", Code = "SD", SortOrder = 99 },
                new { Id = 100, Name = "Somali", Code = "SO", SortOrder = 100 }
            };

            var seedData = countries.Select(c => new Country
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                IsActive = true,
                SortOrder = c.SortOrder,
                CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                Status = Status.Active,
                IsDeleted = false
            }).ToArray();

            builder.HasData(seedData);
        }
    }
}