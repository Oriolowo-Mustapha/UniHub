using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface INotificationRepository
{
    public Task<Notifications> CreateNotification(Notifications notification);
    public Task<IList<Notifications>> GetUserNotifications (Guid userId);
    public Task<bool> MarkNotificationAsRead(Guid notificationId);
    public Task<bool> MarkAllNotificationsAsRead(Guid userId);
    public Task<bool> DeleteNotification (Guid userId);
}