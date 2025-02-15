using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface INotificationRepository
{
    public Task<bool> CreateNotification(Notifications notification);
    public Task<IList<Notifications>> GetUserNotifications (Guid userId);
    public Task<Notifications> UpdateNotificationStatus(Notifications notifications);
    public Task<bool> DeleteNotification (Notifications notifications);
}