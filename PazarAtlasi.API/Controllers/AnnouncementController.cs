using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Models.API.Request;
using PazarAtlasi.CMS.Application.Models.API.Response;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Persistence.Context;

namespace PazarAtlasi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly PazarAtlasiDbContext _dbContext;

        public AnnouncementController(PazarAtlasiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get announcement by ID with full details
        /// </summary>
        /// <param name="id">Announcement ID</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Complete announcement data</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AnnouncementResponse>> GetAnnouncement(int id, [FromQuery] string culture = "tr-TR")
        {
            try
            {
                // Get language by culture
                var language = await _dbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                // Get announcement with translations
                var announcement = await _dbContext.Announcements
                    .Include(a => a.Translations.Where(t => t.LanguageId == language.Id))
                    .FirstOrDefaultAsync(a => a.Id == id && a.Status == Status.Active && !a.IsDeleted);

                if (announcement == null)
                {
                    return NotFound($"Announcement with ID '{id}' not found.");
                }

                var translation = announcement.Translations.FirstOrDefault();
                var now = DateTime.UtcNow;
                var isActive = now >= announcement.PublishStart && now <= announcement.PublishEnd;
                var daysRemaining = (announcement.PublishEnd - now).Days;

                var response = new AnnouncementResponse
                {
                    Id = announcement.Id,
                    Title = translation?.Title ?? announcement.Title,
                    Content = translation?.Content ?? announcement.Content,
                    Summary = translation?.Summary ?? announcement.Summary,
                    CoverImage = announcement.CoverImage,
                    PublishStart = announcement.PublishStart,
                    PublishEnd = announcement.PublishEnd,
                    Status = announcement.Status,
                    CreatedByName = announcement.CreatedByName,
                    IsActive = isActive,
                    DaysRemaining = daysRemaining > 0 ? daysRemaining : 0,
                    CreatedAt = announcement.CreatedAt,
                    UpdatedAt = announcement.UpdatedAt
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get announcement list with filtering and pagination
        /// </summary>
        /// <param name="culture">Culture code</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="onlyActive">Filter only active announcements</param>
        /// <param name="searchTerm">Search term</param>
        /// <returns>Paginated announcement list</returns>
        [HttpGet]
        public async Task<ActionResult<AnnouncementListResponse>> GetAnnouncementList(
            [FromQuery] string culture = "tr-TR",
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] bool? onlyActive = null,
            [FromQuery] string? searchTerm = null)
        {
            try
            {
                // Get language by culture
                var language = await _dbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                // Build query
                var announcementsQuery = _dbContext.Announcements
                    .Include(a => a.Translations.Where(t => t.LanguageId == language.Id))
                    .Where(a => a.Status == Status.Active && !a.IsDeleted);

                // Apply filters
                if (onlyActive.HasValue && onlyActive.Value)
                {
                    var now = DateTime.UtcNow;
                    announcementsQuery = announcementsQuery.Where(a =>
                        a.PublishStart <= now && a.PublishEnd >= now);
                }

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    var search = searchTerm.ToLower();
                    announcementsQuery = announcementsQuery.Where(a =>
                        a.Title.ToLower().Contains(search) ||
                        (a.Summary != null && a.Summary.ToLower().Contains(search)) ||
                        a.Translations.Any(t =>
                            t.Title.ToLower().Contains(search) ||
                            (t.Summary != null && t.Summary.ToLower().Contains(search))));
                }

                // Get total count
                var totalCount = await announcementsQuery.CountAsync();

                // Apply pagination and ordering
                var announcements = await announcementsQuery
                    .OrderByDescending(a => a.PublishStart)
                    .ThenByDescending(a => a.CreatedAt)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var currentTime = DateTime.UtcNow;
                var announcementResponses = announcements.Select(a =>
                {
                    var translation = a.Translations.FirstOrDefault();
                    var isActive = currentTime >= a.PublishStart && currentTime <= a.PublishEnd;
                    var daysRemaining = (a.PublishEnd - currentTime).Days;

                    return new AnnouncementListItemResponse
                    {
                        Id = a.Id,
                        Title = translation?.Title ?? a.Title,
                        Summary = translation?.Summary ?? a.Summary,
                        CoverImage = a.CoverImage,
                        PublishStart = a.PublishStart,
                        PublishEnd = a.PublishEnd,
                        Status = a.Status,
                        IsActive = isActive,
                        DaysRemaining = daysRemaining > 0 ? daysRemaining : 0,
                        CreatedAt = a.CreatedAt
                    };
                }).ToList();

                var response = new AnnouncementListResponse
                {
                    Announcements = announcementResponses,
                    TotalCount = totalCount,
                    PageNumber = page,
                    PageSize = pageSize
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get active announcements (currently published)
        /// </summary>
        /// <param name="culture">Culture code</param>
        /// <param name="count">Number of announcements to return</param>
        /// <returns>List of active announcements</returns>
        [HttpGet("active")]
        public async Task<ActionResult<List<AnnouncementListItemResponse>>> GetActiveAnnouncements(
            [FromQuery] string culture = "tr-TR",
            [FromQuery] int count = 5)
        {
            try
            {
                var language = await _dbContext.Languages
                    .FirstOrDefaultAsync(l => l.Code == culture && !l.IsDeleted);

                if (language == null)
                {
                    return BadRequest($"Language with culture '{culture}' not found.");
                }

                var now = DateTime.UtcNow;
                var announcements = await _dbContext.Announcements
                    .Include(a => a.Translations.Where(t => t.LanguageId == language.Id))
                    .Where(a =>
                        a.Status == Status.Active &&
                        !a.IsDeleted &&
                        a.PublishStart <= now &&
                        a.PublishEnd >= now)
                    .OrderByDescending(a => a.PublishStart)
                    .Take(count)
                    .ToListAsync();

                var announcementResponses = announcements.Select(a =>
                {
                    var translation = a.Translations.FirstOrDefault();
                    var daysRemaining = (a.PublishEnd - now).Days;

                    return new AnnouncementListItemResponse
                    {
                        Id = a.Id,
                        Title = translation?.Title ?? a.Title,
                        Summary = translation?.Summary ?? a.Summary,
                        CoverImage = a.CoverImage,
                        PublishStart = a.PublishStart,
                        PublishEnd = a.PublishEnd,
                        Status = a.Status,
                        IsActive = true,
                        DaysRemaining = daysRemaining > 0 ? daysRemaining : 0,
                        CreatedAt = a.CreatedAt
                    };
                }).ToList();

                return Ok(announcementResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
