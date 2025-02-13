using UniHub.Enum;

namespace UniHub.Entities;

public class Notifications:BaseEntity
{
    public Guid UserId { get; set; }
    public NotificationType NotificationType { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
    public Guid? SourceId { get; set; }
    public User User { get; set; }
}