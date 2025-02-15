namespace UniHub.Entities;

public class Club : BaseEntity
{
	public string ClubName { get; set; }
	public string Desciption { get; set; }
	public Guid CreatorID { get; set; }
	public int? MemberCount { get; set; }
	public string ProfilePic { get; set; }
	public ICollection<User> Users { get; set; } = new List<User>();
}