using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Persistence.Context;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Models.ViewModels;

namespace PazarAtlasi.CMS.Controllers
{
    public class SettingsController : Controller
    {
        private readonly PazarAtlasiDbContext _context;

        public SettingsController(PazarAtlasiDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Countries list page
        /// </summary>
        public async Task<IActionResult> Countries(int page = 1, int pageSize = 20)
        {
            var totalCount = await _context.Countries.CountAsync(c => !c.IsDeleted);

            var countries = await _context.Countries
                .Include(c => c.Continent)
                .Where(c => !c.IsDeleted)
                .OrderBy(c => c.SortOrder)
                .ThenBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CountryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    IsActive = c.IsActive,
                    SortOrder = c.SortOrder,
                    ContinentId = c.ContinentId,
                    ContinentName = c.Continent != null ? c.Continent.Name : null,
                    IsPopular = c.IsPopular,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();

            // Get continents for filter
            var continents = await _context.Continents
                .Where(c => !c.IsDeleted && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .Select(c => new ContinentViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    IsActive = c.IsActive,
                    SortOrder = c.SortOrder,
                    CountryCount = c.Countries.Count(co => !co.IsDeleted),
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();

            // Get popular countries
            var popularCountries = await _context.Countries
                .Include(c => c.Continent)
                .Where(c => !c.IsDeleted && c.IsPopular && c.IsActive)
                .OrderBy(c => c.Name)
                .Select(c => new CountryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    IsActive = c.IsActive,
                    SortOrder = c.SortOrder,
                    ContinentId = c.ContinentId,
                    ContinentName = c.Continent != null ? c.Continent.Name : null,
                    IsPopular = c.IsPopular,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();

            var model = new CountryListViewModel
            {
                Countries = countries,
                Continents = continents,
                PopularCountries = popularCountries,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// Languages list page
        /// </summary>
        public async Task<IActionResult> Languages(int page = 1, int pageSize = 20)
        {
            var totalCount = await _context.Languages.CountAsync(l => !l.IsDeleted);

            var languages = await _context.Languages
                .Where(l => !l.IsDeleted)
                .OrderByDescending(l => l.IsDefault)
                .ThenBy(l => l.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault,
                    CreatedAt = l.CreatedAt,
                    UpdatedAt = l.UpdatedAt
                })
                .ToListAsync();

            var model = new LanguageListViewModel
            {
                Languages = languages,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// Toggle country active status
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ToggleCountryStatus(int id)
        {
            try
            {
                var country = await _context.Countries.FindAsync(id);
                if (country == null)
                {
                    return Json(new { success = false, message = "Country not found." });
                }

                country.IsActive = !country.IsActive;
                country.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return Json(new { 
                    success = true, 
                    message = $"Country {(country.IsActive ? "activated" : "deactivated")} successfully.",
                    isActive = country.IsActive
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while updating country status." });
            }
        }

        /// <summary>
        /// Set default language
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SetDefaultLanguage(int id)
        {
            try
            {
                // Remove default from all languages
                var allLanguages = await _context.Languages.Where(l => !l.IsDeleted).ToListAsync();
                foreach (var lang in allLanguages)
                {
                    lang.IsDefault = false;
                }

                // Set new default
                var language = allLanguages.FirstOrDefault(l => l.Id == id);
                if (language == null)
                {
                    return Json(new { success = false, message = "Language not found." });
                }

                language.IsDefault = true;
                language.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return Json(new { 
                    success = true, 
                    message = $"{language.Name} set as default language successfully."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while setting default language." });
            }
        }
    }
}