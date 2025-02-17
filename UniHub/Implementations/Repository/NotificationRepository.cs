using Microsoft.EntityFrameworkCore;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.UniHubDbContext;

namespace UniHub.Implementations.Repository;

public class NotificationRepository:INotificationRepository
{
    private readonly UniHubContext _uniHubContext;

    public NotificationRepository(UniHubContext uniHubContext)
    {
        uniHubContext = _uniHubContext;
    }
    
    public async Task<bool> CreateNotification(Notifications notification)
    {
        await _uniHubContext.Notifications.AddAsync(notification);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<IList<Notifications>> GetUserNotifications(Guid userId)
    {
        var notification = await _uniHubContext.Notifications
            .Where(not => not.UserId == userId)
            .Include(not => not.SourceId)
            .AsNoTracking()
            .ToListAsync();
        return notification;
    }

    public async Task<Notifications> GetNotificationById(Guid NotificationId)
    {
        return await _uniHubContext.Notifications.FindAsync(NotificationId);
    }

    public async Task<Notifications> UpdateNotificationStatus(Notifications notifications)
    {
        _uniHubContext.Notifications.Update(notifications);
        await _uniHubContext.SaveChangesAsync();
        return notifications;
    }

    public async Task<bool> DeleteNotification(Notifications notifications)
    {
        _uniHubContext.Notifications.Remove(notifications);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }
}