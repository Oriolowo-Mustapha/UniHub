using UniHub.DTOs;
using UniHub.Entities;
using UniHub.Enum;
using UniHub.Interfaces.Repository;
using UniHub.Interfaces.Services;

namespace UniHub.Implementations.Services;

public class NotificationService:INotificationService
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<BaseResponse<bool>> CreateNotificationLike(CreateNotificationRequestModel model)
    {
        var notification = new Notifications
        {
            DateOfCreation = DateTime.Today,
            UserId = model.UserId,
            NotificationType = NotificationType.Like,
            Content = model.Content,
            Status = model.Status,
            SourceId = model.SourceId,
        };
        var createNotification = _notificationRepository.CreateNotification(notification);
        if (createNotification == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Notification Couldnt Be Created",
                Status = true
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Notification Created Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<bool>> CreateNotificationFollow(CreateNotificationRequestModel model)
    {
        var notification = new Notifications
        {
            DateOfCreation = DateTime.Today,
            UserId = model.UserId,
            NotificationType = NotificationType.Follow,
            Content = model.Content,
            Status = model.Status,
            SourceId = model.SourceId,
        };
        var createNotification = _notificationRepository.CreateNotification(notification);
        if (createNotification == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Notification Couldnt Be Created",
                Status = true
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Notification Created Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<bool>> CreateNotificationComment(CreateNotificationRequestModel model)
    {
        var notification = new Notifications
        {
            DateOfCreation = DateTime.Today,
            UserId = model.UserId,
            NotificationType = NotificationType.Comment,
            Content = model.Content,
            Status = model.Status,
            SourceId = model.SourceId,
        };
        var createNotification = _notificationRepository.CreateNotification(notification);
        if (createNotification == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Notification Couldnt Be Created",
                Status = true
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Notification Created Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<IList<NotificationDto>>> GetUserNotifications(Guid userId)
    {
        var notifications = await _notificationRepository.GetUserNotifications(userId);
        if (!notifications.Any())
        {
            return new BaseResponse<IList<NotificationDto>>
            {
                Message = "No Notifications Yet",
                Status = false
            };
        }

        var notification = notifications.Select(notifications => new NotificationDto
        {
            Id = notifications.Id,
            UserId = notifications.UserId,
            NotificationType = notifications.NotificationType,
            Content = notifications.Content,
            Status = notifications.Status,
            SourceId = notifications.SourceId,
        }).ToList();

        return new BaseResponse<IList<NotificationDto>>
        {
            Message = "Users successfully fetched!",
            Status = true,
            Data = notification
        };
    }

    public async Task<BaseResponse<bool>> MarkNotificationAsRead(Guid NotificationId)
    {
        var getNotification = await _notificationRepository.GetNotificationById(NotificationId);
        if (getNotification == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Notification Unavailabe",
                Status = false
            };
        }

        var notification = new Notifications
        {
           Status = getNotification.Status
        };

        var update = _notificationRepository.UpdateNotificationStatus(notification);
        return new BaseResponse<bool>
        {
            Message = "Status Successful Changed",
            Status = true,
        };
    }
    

    public async Task<BaseResponse<bool>> DeleteNotification(Guid userId)
    {
        var post = await _notificationRepository.GetNotificationById(userId);
        if (post == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Notifications not found!",
                Status = false
            };
        }
        var deletePost = await _notificationRepository.DeleteNotification(post);
        if (deletePost == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Failed to delete Notifications!",
                Status = false
            };
        }
        return new BaseResponse<bool>
        {
            Message = "Notifications deleted successfully!",
            Status = true
        };
    }
}