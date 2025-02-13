namespace UniHub.Entities;

public class Likes:BaseEntity
{
    public Guid UserID { get; set; }
    public Guid PostId { get; set; }
    public Guid CommentsId { get; set; }
    public User User { get; set; }
    public Posts Posts { get; set; }
}