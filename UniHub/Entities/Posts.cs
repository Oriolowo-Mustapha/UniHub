namespace UniHub.Entities;

public class Posts:BaseEntity
{
    public Guid UserID { get; set; }
    public Guid ClubID { get; set; }
    public string Content { get; set; }
    public int? NoLikes { get; set; }
    public int? NoComments { get; set; }
    public string MediaUrls { get; set; }
    public User User { get; set; }
    public ICollection<Likes> Likes = new List<Likes>();
    public ICollection<Comments> Comments = new List<Comments>();
    public ICollection<Repost> Reposts = new List<Repost>();
    
    public void updateNoLikes(int? NoLike)
    {
        NoLike = NoLikes;

    }
    
    public void updateNoComment(int? NoComment)
    {
        NoComment = NoComments;

    }
}