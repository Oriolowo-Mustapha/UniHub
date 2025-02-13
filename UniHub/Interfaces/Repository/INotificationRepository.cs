using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface INotificationRepository
{
    public Task<Notifications> CreateNotification(Notifications notification);
    public Task<IList<Notifications>> GetUserNotifications (int userId);
    public Task<bool> MarkNotificationAsRead(int notificationId);
    public Task<bool> MarkAllNotificationsAsRead(int userId);
    public Task<bool> DeleteNotification (int userId);
}