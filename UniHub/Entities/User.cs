namespace UniHub.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public Guid UniversityID { get; set; }
    public string Password { get; set; }
    public string ProfilePic { get; set; }
    public string Bio { get; set; }
    public int? NoPosts { get; set; }
    public int? NoLikes { get; set; }
    public int? NoFollowers { get; set; }
    public ICollection<UserFollow> Followers { get; set; } = new List<UserFollow>();
    public ICollection<Posts> Posts { get; set; } = new List<Posts>();
    public ICollection<Repost> Reposts { get; set; } = new List<Repost>();
    public ICollection<Likes> Likes { get; set; } = new List<Likes>();
    public ICollection<Club> Clubs { get; set; } = new List<Club>();
    public ICollection<Events> Events { get; set; } = new List<Events>();
    public ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();
}