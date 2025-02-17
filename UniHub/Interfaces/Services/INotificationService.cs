using UniHub.DTOs;

namespace UniHub.Interfaces.Services;

public interface INotificationService
{
    public Task<BaseResponse<bool>> CreateNotificationLike(CreateNotificationRequestModel model);
    public Task<BaseResponse<bool>> CreateNotificationFollow(CreateNotificationRequestModel model);
    public Task<BaseResponse<bool>> CreateNotificationComment(CreateNotificationRequestModel model);
    public Task<BaseResponse<IList<NotificationDto>>> GetUserNotifications (Guid userId);
    public Task<BaseResponse<bool>> MarkNotificationAsRead(Guid notificationId);
    public Task<BaseResponse<bool>> DeleteNotification (Guid userId);
}