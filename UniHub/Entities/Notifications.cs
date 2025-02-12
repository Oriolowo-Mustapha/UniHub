using UniHub.Enum;

namespace UniHub.Entities;

public class Notifications:BaseEntity
{
    public Guid UserId { get; set; }
    public NotificationType NotificationType { get; set; }
    public string Content { get; set; }
    public string SourceType { get; set; }
    public Guid? SourceId { get; set; }
}