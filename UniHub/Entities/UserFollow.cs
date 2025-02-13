namespace UniHub.Entities;

public class UserFollow:BaseEntity
{
    public Guid FollowerId { get; set; }
    public Guid FollowingID { get; set; }
    public ICollection<User> Followers { get; set; } = new List<User>();
}