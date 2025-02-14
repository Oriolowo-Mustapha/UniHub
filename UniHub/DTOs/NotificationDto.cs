using System.ComponentModel.DataAnnotations;
using UniHub.Entities;
using UniHub.Enum;

namespace UniHub.DTOs;

public class NotificationDto
{
    public Guid UserId { get; set; }
    public NotificationType NotificationType { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
    public Guid? SourceId { get; set; }
}

public class CreateNotificationRequestModel
{
    [Required]
    public Guid UserId { get; set; }
    
    public NotificationType NotificationType { get; set; }
    
    public string Content { get; set; }
    public string Status { get; set; }
    public Guid? SourceId { get; set; }
}