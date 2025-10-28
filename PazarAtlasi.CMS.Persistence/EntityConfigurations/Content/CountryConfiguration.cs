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
            builder.Property(c => c.ContinentId).HasColumnName("ContinentId");
            builder.Property(c => c.IsPopular).HasColumnName("IsPopular").HasDefaultValue(false);
            builder.Property(c => c.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(c => c.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(c => c.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(c => c.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(c => c.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(c => c.Continent)
                   .WithMany(co => co.Countries)
                   .HasForeignKey(c => c.ContinentId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(c => c.Code).HasDatabaseName("IX_Countries_Code");
            builder.HasIndex(c => c.IsActive).HasDatabaseName("IX_Countries_IsActive");
            builder.HasIndex(c => c.SortOrder).HasDatabaseName("IX_Countries_SortOrder");
            builder.HasIndex(c => c.ContinentId).HasDatabaseName("IX_Countries_ContinentId");
            builder.HasIndex(c => c.IsPopular).HasDatabaseName("IX_Countries_IsPopular");

            // Query Filter
            builder.HasQueryFilter(c => !c.IsDeleted);

            // Seed Data - Mock countries with continent relationships and popular flags
            var countries = new[]
            {
                // Afrika (ContinentId = 1)
                new { Id = 1, Name = "Mısır", Code = "EG", SortOrder = 1, ContinentId = 1, IsPopular = false },
                new { Id = 2, Name = "Gabon", Code = "GA", SortOrder = 2, ContinentId = 1, IsPopular = false },
                new { Id = 3, Name = "Gana", Code = "GH", SortOrder = 3, ContinentId = 1, IsPopular = false },
                new { Id = 4, Name = "Etiyopya", Code = "ET", SortOrder = 4, ContinentId = 1, IsPopular = false },
                new { Id = 5, Name = "Kenya", Code = "KE", SortOrder = 5, ContinentId = 1, IsPopular = false },
                new { Id = 6, Name = "Tanzanya", Code = "TZ", SortOrder = 6, ContinentId = 1, IsPopular = false },
                new { Id = 7, Name = "Güney Afrika", Code = "ZA", SortOrder = 7, ContinentId = 1, IsPopular = true },
                new { Id = 8, Name = "Nijerya", Code = "NG", SortOrder = 8, ContinentId = 1, IsPopular = false },
                new { Id = 9, Name = "Senegal", Code = "SN", SortOrder = 9, ContinentId = 1, IsPopular = false },
                new { Id = 10, Name = "Fas", Code = "MA", SortOrder = 10, ContinentId = 1, IsPopular = false },
                new { Id = 11, Name = "Tunus", Code = "TN", SortOrder = 11, ContinentId = 1, IsPopular = false },
                new { Id = 12, Name = "Cezayir", Code = "DZ", SortOrder = 12, ContinentId = 1, IsPopular = false },
                new { Id = 13, Name = "Uganda", Code = "UG", SortOrder = 13, ContinentId = 1, IsPopular = false },
                new { Id = 14, Name = "Ruanda", Code = "RW", SortOrder = 14, ContinentId = 1, IsPopular = false },
                new { Id = 15, Name = "Kamerun", Code = "CM", SortOrder = 15, ContinentId = 1, IsPopular = false },
                
                // Avrupa (ContinentId = 2)
                new { Id = 16, Name = "Almanya", Code = "DE", SortOrder = 16, ContinentId = 2, IsPopular = true },
                new { Id = 17, Name = "Fransa", Code = "FR", SortOrder = 17, ContinentId = 2, IsPopular = true },
                new { Id = 18, Name = "İngiltere", Code = "GB", SortOrder = 18, ContinentId = 2, IsPopular = true },
                new { Id = 19, Name = "İtalya", Code = "IT", SortOrder = 19, ContinentId = 2, IsPopular = true },
                new { Id = 20, Name = "İspanya", Code = "ES", SortOrder = 20, ContinentId = 2, IsPopular = true },
                new { Id = 21, Name = "Hollanda", Code = "NL", SortOrder = 21, ContinentId = 2, IsPopular = false },
                new { Id = 22, Name = "Belçika", Code = "BE", SortOrder = 22, ContinentId = 2, IsPopular = false },
                new { Id = 23, Name = "Polonya", Code = "PL", SortOrder = 23, ContinentId = 2, IsPopular = false },
                new { Id = 24, Name = "Romanya", Code = "RO", SortOrder = 24, ContinentId = 2, IsPopular = false },
                new { Id = 25, Name = "Yunanistan", Code = "GR", SortOrder = 25, ContinentId = 2, IsPopular = false },
                new { Id = 26, Name = "Portekiz", Code = "PT", SortOrder = 26, ContinentId = 2, IsPopular = false },
                new { Id = 27, Name = "Avusturya", Code = "AT", SortOrder = 27, ContinentId = 2, IsPopular = false },
                new { Id = 28, Name = "İsviçre", Code = "CH", SortOrder = 28, ContinentId = 2, IsPopular = false },
                new { Id = 29, Name = "İsveç", Code = "SE", SortOrder = 29, ContinentId = 2, IsPopular = false },
                new { Id = 30, Name = "Norveç", Code = "NO", SortOrder = 30, ContinentId = 2, IsPopular = false },
                new { Id = 31, Name = "Danimarka", Code = "DK", SortOrder = 31, ContinentId = 2, IsPopular = false },
                new { Id = 32, Name = "Finlandiya", Code = "FI", SortOrder = 32, ContinentId = 2, IsPopular = false },
                new { Id = 33, Name = "Çek Cumhuriyeti", Code = "CZ", SortOrder = 33, ContinentId = 2, IsPopular = false },
                new { Id = 34, Name = "Macaristan", Code = "HU", SortOrder = 34, ContinentId = 2, IsPopular = false },
                new { Id = 35, Name = "Bulgaristan", Code = "BG", SortOrder = 35, ContinentId = 2, IsPopular = false },
                new { Id = 36, Name = "Hırvatistan", Code = "HR", SortOrder = 36, ContinentId = 2, IsPopular = false },
                new { Id = 37, Name = "Slovakya", Code = "SK", SortOrder = 37, ContinentId = 2, IsPopular = false },
                new { Id = 38, Name = "Slovenya", Code = "SI", SortOrder = 38, ContinentId = 2, IsPopular = false },
                new { Id = 39, Name = "Litvanya", Code = "LT", SortOrder = 39, ContinentId = 2, IsPopular = false },
                new { Id = 40, Name = "Letonya", Code = "LV", SortOrder = 40, ContinentId = 2, IsPopular = false },
                new { Id = 41, Name = "Estonya", Code = "EE", SortOrder = 41, ContinentId = 2, IsPopular = false },
                
                // Kuzey Amerika (ContinentId = 3)
                new { Id = 42, Name = "Amerika Birleşik Devletleri", Code = "US", SortOrder = 42, ContinentId = 3, IsPopular = true },
                new { Id = 43, Name = "Kanada", Code = "CA", SortOrder = 43, ContinentId = 3, IsPopular = true },
                new { Id = 44, Name = "Meksika", Code = "MX", SortOrder = 44, ContinentId = 3, IsPopular = false },
                
                // Güney Amerika (ContinentId = 4)
                new { Id = 45, Name = "Brezilya", Code = "BR", SortOrder = 45, ContinentId = 4, IsPopular = true },
                new { Id = 46, Name = "Arjantin", Code = "AR", SortOrder = 46, ContinentId = 4, IsPopular = false },
                new { Id = 47, Name = "Şili", Code = "CL", SortOrder = 47, ContinentId = 4, IsPopular = false },
                new { Id = 48, Name = "Kolombiya", Code = "CO", SortOrder = 48, ContinentId = 4, IsPopular = false },
                new { Id = 49, Name = "Peru", Code = "PE", SortOrder = 49, ContinentId = 4, IsPopular = false },
                new { Id = 50, Name = "Venezuela", Code = "VE", SortOrder = 50, ContinentId = 4, IsPopular = false },
                new { Id = 51, Name = "Ekvador", Code = "EC", SortOrder = 51, ContinentId = 4, IsPopular = false },
                new { Id = 52, Name = "Uruguay", Code = "UY", SortOrder = 52, ContinentId = 4, IsPopular = false },
                new { Id = 53, Name = "Paraguay", Code = "PY", SortOrder = 53, ContinentId = 4, IsPopular = false },
                new { Id = 54, Name = "Bolivya", Code = "BO", SortOrder = 54, ContinentId = 4, IsPopular = false },
                
                // Asya (ContinentId = 5)
                new { Id = 55, Name = "Çin", Code = "CN", SortOrder = 55, ContinentId = 5, IsPopular = true },
                new { Id = 56, Name = "Japonya", Code = "JP", SortOrder = 56, ContinentId = 5, IsPopular = true },
                new { Id = 57, Name = "Güney Kore", Code = "KR", SortOrder = 57, ContinentId = 5, IsPopular = false },
                new { Id = 58, Name = "Hindistan", Code = "IN", SortOrder = 58, ContinentId = 5, IsPopular = true },
                new { Id = 59, Name = "Pakistan", Code = "PK", SortOrder = 59, ContinentId = 5, IsPopular = false },
                new { Id = 60, Name = "Bangladeş", Code = "BD", SortOrder = 60, ContinentId = 5, IsPopular = false },
                new { Id = 61, Name = "Endonezya", Code = "ID", SortOrder = 61, ContinentId = 5, IsPopular = false },
                new { Id = 62, Name = "Filipinler", Code = "PH", SortOrder = 62, ContinentId = 5, IsPopular = false },
                new { Id = 63, Name = "Vietnam", Code = "VN", SortOrder = 63, ContinentId = 5, IsPopular = false },
                new { Id = 64, Name = "Tayland", Code = "TH", SortOrder = 64, ContinentId = 5, IsPopular = false },
                new { Id = 65, Name = "Malezya", Code = "MY", SortOrder = 65, ContinentId = 5, IsPopular = false },
                new { Id = 66, Name = "Singapur", Code = "SG", SortOrder = 66, ContinentId = 5, IsPopular = false },
                new { Id = 67, Name = "Myanmar", Code = "MM", SortOrder = 67, ContinentId = 5, IsPopular = false },
                new { Id = 68, Name = "Kamboçya", Code = "KH", SortOrder = 68, ContinentId = 5, IsPopular = false },
                new { Id = 69, Name = "Laos", Code = "LA", SortOrder = 69, ContinentId = 5, IsPopular = false },
                new { Id = 70, Name = "Sri Lanka", Code = "LK", SortOrder = 70, ContinentId = 5, IsPopular = false },
                new { Id = 71, Name = "Nepal", Code = "NP", SortOrder = 71, ContinentId = 5, IsPopular = false },
                new { Id = 74, Name = "Rusya", Code = "RU", SortOrder = 74, ContinentId = 5, IsPopular = true },
                new { Id = 75, Name = "Ukrayna", Code = "UA", SortOrder = 75, ContinentId = 2, IsPopular = false },
                new { Id = 76, Name = "Kazakistan", Code = "KZ", SortOrder = 76, ContinentId = 5, IsPopular = false },
                new { Id = 77, Name = "Özbekistan", Code = "UZ", SortOrder = 77, ContinentId = 5, IsPopular = false },
                new { Id = 78, Name = "Türkmenistan", Code = "TM", SortOrder = 78, ContinentId = 5, IsPopular = false },
                new { Id = 79, Name = "Kırgızistan", Code = "KG", SortOrder = 79, ContinentId = 5, IsPopular = false },
                new { Id = 80, Name = "Tacikistan", Code = "TJ", SortOrder = 80, ContinentId = 5, IsPopular = false },
                new { Id = 81, Name = "Azerbaycan", Code = "AZ", SortOrder = 81, ContinentId = 5, IsPopular = false },
                new { Id = 82, Name = "Gürcistan", Code = "GE", SortOrder = 82, ContinentId = 5, IsPopular = false },
                new { Id = 83, Name = "Ermenistan", Code = "AM", SortOrder = 83, ContinentId = 5, IsPopular = false },
                new { Id = 84, Name = "İran", Code = "IR", SortOrder = 84, ContinentId = 5, IsPopular = false },
                new { Id = 85, Name = "Irak", Code = "IQ", SortOrder = 85, ContinentId = 5, IsPopular = false },
                new { Id = 86, Name = "Suriye", Code = "SY", SortOrder = 86, ContinentId = 5, IsPopular = false },
                new { Id = 87, Name = "Ürdün", Code = "JO", SortOrder = 87, ContinentId = 5, IsPopular = false },
                new { Id = 88, Name = "Lübnan", Code = "LB", SortOrder = 88, ContinentId = 5, IsPopular = false },
                new { Id = 89, Name = "İsrail", Code = "IL", SortOrder = 89, ContinentId = 5, IsPopular = false },
                new { Id = 90, Name = "Suudi Arabistan", Code = "SA", SortOrder = 90, ContinentId = 5, IsPopular = false },
                new { Id = 91, Name = "Birleşik Arap Emirlikleri", Code = "AE", SortOrder = 91, ContinentId = 5, IsPopular = false },
                new { Id = 92, Name = "Kuveyt", Code = "KW", SortOrder = 92, ContinentId = 5, IsPopular = false },
                new { Id = 93, Name = "Katar", Code = "QA", SortOrder = 93, ContinentId = 5, IsPopular = false },
                new { Id = 94, Name = "Bahreyn", Code = "BH", SortOrder = 94, ContinentId = 5, IsPopular = false },
                new { Id = 95, Name = "Umman", Code = "OM", SortOrder = 95, ContinentId = 5, IsPopular = false },
                new { Id = 96, Name = "Yemen", Code = "YE", SortOrder = 96, ContinentId = 5, IsPopular = false },
                new { Id = 97, Name = "Afganistan", Code = "AF", SortOrder = 97, ContinentId = 5, IsPopular = false },
                new { Id = 98, Name = "Libya", Code = "LY", SortOrder = 98, ContinentId = 1, IsPopular = false },
                new { Id = 99, Name = "Sudan", Code = "SD", SortOrder = 99, ContinentId = 1, IsPopular = false },
                new { Id = 100, Name = "Somali", Code = "SO", SortOrder = 100, ContinentId = 1, IsPopular = false },
                
                // Okyanusya (ContinentId = 6)
                new { Id = 72, Name = "Avustralya", Code = "AU", SortOrder = 72, ContinentId = 6, IsPopular = true },
                new { Id = 73, Name = "Yeni Zelanda", Code = "NZ", SortOrder = 73, ContinentId = 6, IsPopular = false }
            };

            var seedData = countries.Select(c => new Country
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                IsActive = true,
                SortOrder = c.SortOrder,
                ContinentId = c.ContinentId,
                IsPopular = c.IsPopular,
                CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                Status = Status.Active,
                IsDeleted = false
            }).ToArray();

            builder.HasData(seedData);
        }
    }
}