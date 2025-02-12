namespace UniHub.Entities;

public class Comments:BaseEntity
{
    public Guid PostID { get; set; }
    public Guid UserID { get; set; } 
    public string Content { get; set; }
    public int? LikeCount { get; set; }
    public int? ReplyComment { get; set; }
    public ICollection<Likes> Likes = new List<Likes>();
}