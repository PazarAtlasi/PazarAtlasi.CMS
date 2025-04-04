using PazarAtlasi.CMS.Domain.Entities;
using PazarAtlasi.CMS.Domain.Interfaces;

namespace PazarAtlasi.CMS.Application.Interfaces.Repositories;

public interface IAnnouncementRepository : IGenericRepository<Announcement>
{
    Task<List<Announcement>> GetActiveAnnouncementsAsync();
    Task<List<Announcement>> GetAnnouncementsByDateRangeAsync(DateTime startDate, DateTime endDate);
} 