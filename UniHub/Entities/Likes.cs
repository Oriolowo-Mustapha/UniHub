namespace UniHub.Entities;

public class Likes:BaseEntity
{
    public Guid UserID { get; set; }
    public Guid postId { get; set; }
    public Guid CommentsId { get; set; }
}