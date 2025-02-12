namespace UniHub.Entities;

public class UserFollow:BaseEntity
{
    public Guid FollowerId { get; set; }
    public Guid FollowedId { get; set; }
}