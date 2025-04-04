using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Interfaces.Repositories;
using PazarAtlasi.CMS.Domain.Entities;
using PazarAtlasi.CMS.Domain.Interfaces;
using PazarAtlasi.CMS.Persistence.Context;

namespace PazarAtlasi.CMS.Persistence.Repositories;

public class AnnouncementRepository : IAnnouncementRepository
{
    private readonly ApplicationDbContext _context;

    public AnnouncementRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Announcement> GetByIdAsync(int id)
    {
        return await _context.Announcements.FindAsync(id);
    }

    public async Task<IEnumerable<Announcement>> GetAllAsync()
    {
        return await _context.Announcements.ToListAsync();
    }

    public async Task<IEnumerable<Announcement>> FindAsync(Expression<Func<Announcement, bool>> predicate)
    {
        return await _context.Announcements.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(Announcement entity)
    {
        await _context.Announcements.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<Announcement> entities)
    {
        await _context.Announcements.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public void Update(Announcement entity)
    {
        _context.Announcements.Update(entity);
        _context.SaveChanges();
    }

    public void Remove(Announcement entity)
    {
        _context.Announcements.Remove(entity);
        _context.SaveChanges();
    }

    public void RemoveRange(IEnumerable<Announcement> entities)
    {
        _context.Announcements.RemoveRange(entities);
        _context.SaveChanges();
    }

    public async Task<List<Announcement>> GetActiveAnnouncementsAsync()
    {
        return await _context.Announcements
            .Where(a => a.IsActive)
            .OrderByDescending(a => a.PublishDate)
            .ToListAsync();
    }

    public async Task<List<Announcement>> GetAnnouncementsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Announcements
            .Where(a => a.PublishDate >= startDate && a.PublishDate <= endDate)
            .OrderByDescending(a => a.PublishDate)
            .ToListAsync();
    }
} 