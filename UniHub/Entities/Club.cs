namespace UniHub.Entities;

public class Club : BaseEntity
{
	public string ClubName { get; set; }
	public string Desciption { get; set; }
	public Guid CreatorID { get; set; }
	public int? MemberCount { get; set; }
	public User Users { get; set; }
	public ICollection<User> Members { get; set; } = new List<User>();
}