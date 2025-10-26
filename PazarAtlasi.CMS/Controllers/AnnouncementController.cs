using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Persistence.Context;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Models.ViewModels;

namespace PazarAtlasi.CMS.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly PazarAtlasiDbContext _context;
        private readonly IMediaUploadService _mediaUploadService;

        public AnnouncementController(
            PazarAtlasiDbContext context,
            IMediaUploadService mediaUploadService)
        {
            _context = context;
            _mediaUploadService = mediaUploadService;
        }

        /// <summary>
        /// Duyurular listesi sayfası
        /// </summary>
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string? search = null, string? status = null)
        {
            var query = _context.Announcements.AsQueryable();

            // Arama filtresi
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Title.Contains(search) || a.Summary.Contains(search));
            }

            // Durum filtresi
            if (!string.IsNullOrEmpty(status))
            {
                if (Enum.TryParse<Status>(status, out var statusEnum))
                {
                    query = query.Where(a => a.Status == statusEnum);
                }
            }

            var totalCount = await query.CountAsync();

            var announcements = await query
                .OrderByDescending(a => a.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new AnnouncementListViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Summary = a.Summary,
                    PublishStart = a.PublishStart,
                    PublishEnd = a.PublishEnd,
                    Status = a.Status,
                    CreatedAt = a.CreatedAt,
                })
                .ToListAsync();

            // Status color ve text'i memory'de hesapla
            foreach (var announcement in announcements)
            {
                announcement.StatusColor = GetStatusColor(announcement.Status, announcement.PublishStart, announcement.PublishEnd);
                announcement.StatusText = GetStatusText(announcement.Status, announcement.PublishStart, announcement.PublishEnd);
            }

            var model = new AnnouncementListResponse
            {
                Announcements = announcements,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize,
                Search = search,
                StatusFilter = status
            };

            return View(model);
        }

        /// <summary>
        /// Yeni duyuru oluşturma sayfası
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            var model = new AnnouncementCreateViewModel
            {
                PublishStart = DateTime.Now,
                PublishEnd = DateTime.Now.AddDays(30),
                Status = Status.Draft
            };

            return View(model);
        }

        /// <summary>
        /// Yeni duyuru oluşturma - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnnouncementCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var announcement = new PazarAtlasi.CMS.Domain.Entities.Announcement.Announcement
                {
                    Title = model.Title,
                    Content = model.Content,
                    Summary = model.Summary,
                    CoverImage = model.CoverImage,
                    PublishStart = model.PublishStart,
                    PublishEnd = model.PublishEnd,
                    Status = model.Status,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Announcements.Add(announcement);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Duyuru başarıyla oluşturuldu.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Duyuru oluşturulurken bir hata oluştu: " + ex.Message);
                return View(model);
            }
        }

        /// <summary>
        /// Duyuru düzenleme sayfası
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null)
            {
                TempData["ErrorMessage"] = "Duyuru bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            var model = new AnnouncementEditViewModel
            {
                Id = announcement.Id,
                Title = announcement.Title,
                Content = announcement.Content,
                Summary = announcement.Summary,
                CoverImage = announcement.CoverImage,
                PublishStart = announcement.PublishStart,
                PublishEnd = announcement.PublishEnd,
                Status = announcement.Status
            };

            return View(model);
        }

        /// <summary>
        /// Duyuru düzenleme - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AnnouncementEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var announcement = await _context.Announcements.FindAsync(model.Id);
                if (announcement == null)
                {
                    TempData["ErrorMessage"] = "Duyuru bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                announcement.Title = model.Title;
                announcement.Content = model.Content;
                announcement.Summary = model.Summary;
                announcement.CoverImage = model.CoverImage;
                announcement.PublishStart = model.PublishStart;
                announcement.PublishEnd = model.PublishEnd;
                announcement.Status = model.Status;
                announcement.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Duyuru başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Duyuru güncellenirken bir hata oluştu: " + ex.Message);
                return View(model);
            }
        }

        /// <summary>
        /// Duyuru silme
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var announcement = await _context.Announcements.FindAsync(id);
                if (announcement == null)
                {
                    return Json(new { success = false, message = "Duyuru bulunamadı." });
                }

                announcement.IsDeleted = true;
                announcement.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Duyuru başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Duyuru silinirken bir hata oluştu: " + ex.Message });
            }
        }

        /// <summary>
        /// Taslak olarak kaydet
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveAsDraft(int id)
        {
            try
            {
                var announcement = await _context.Announcements.FindAsync(id);
                if (announcement == null)
                {
                    return Json(new { success = false, message = "Duyuru bulunamadı." });
                }

                announcement.Status = Status.Draft;
                announcement.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Duyuru taslak olarak kaydedildi." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        /// <summary>
        /// Yayınla
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Publish(int id)
        {
            try
            {
                var announcement = await _context.Announcements.FindAsync(id);
                if (announcement == null)
                {
                    return Json(new { success = false, message = "Duyuru bulunamadı." });
                }

                announcement.Status = Status.Active;
                announcement.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Duyuru yayınlandı." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        /// <summary>
        /// Görsel yükleme
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UploadCoverImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return Json(new { success = false, message = "Dosya seçilmedi." });
                }

                var result = await _mediaUploadService.UploadImageAsync(file, "announcements");

                return Json(new
                {
                    success = result.Success,
                    message = result.Message,
                    url = result.Url,
                    fileName = result.FileName
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Görsel yüklenirken bir hata oluştu: " + ex.Message });
            }
        }

        #region Private Methods

        private static string GetStatusColor(Status status, DateTime publishStart, DateTime publishEnd)
        {
            var now = DateTime.UtcNow;

            if (status == Status.Draft)
                return "blue"; // 🔵 Mavi: Henüz yayınlanmamış

            if (status == Status.Active)
            {
                if (now >= publishStart && now <= publishEnd)
                    return "green"; // 🟢 Yeşil: Şu anda yayında

                if (now > publishEnd)
                    return "gray"; // ⚪ Gri: Yayın süresi dolmuş

                if (publishEnd.Subtract(now).TotalDays <= 7)
                    return "yellow"; // 🟡 Sarı: Yayının bitmesine 7 günden az kalmış
            }

            return "gray";
        }

        private static string GetStatusText(Status status, DateTime publishStart, DateTime publishEnd)
        {
            var now = DateTime.UtcNow;

            if (status == Status.Draft)
                return "Taslak";

            if (status == Status.Active)
            {
                if (now >= publishStart && now <= publishEnd)
                    return "Yayında";

                if (now > publishEnd)
                    return "Süresi Dolmuş";

                if (publishEnd.Subtract(now).TotalDays <= 7)
                    return "Yakında Bitecek";

                if (now < publishStart)
                    return "Yayın Bekliyor";
            }

            return "Bilinmeyen";
        }

        #endregion
    }
}