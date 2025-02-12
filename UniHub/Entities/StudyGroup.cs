namespace UniHub.Entities;

public class StudyGroup:BaseEntity
{
    public string GroupName { get; set; }
    public string Descrption { get; set; }
    public int MemberCount { get; set; }
    public string ProfilePic { get; set; }
    public ICollection<User> GroupMembers { get; set; } = new List<User>();
    public ICollection<Comments> Comments { get; set; } = new List<Comments>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}