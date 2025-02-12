namespace UniHub.Entities;

public class Posts
{
    public Guid UserID { get; set; }
    public string Content { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int NoLikes { get; set; }
    public int NoComments { get; set; }
    public int RepostCount { get; set; }
    public string Visiblity { get; set; }
    public string MediaUrls { get; set; }
    public ICollection<Likes> Likes = new List<Likes>();
    public ICollection<Comments> Comments = new List<Comments>();
}