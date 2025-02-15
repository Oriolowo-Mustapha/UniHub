namespace UniHub.Entities;

public class Events : BaseEntity
{
	public string Title { get; set; }
	public string Description { get; set; }
	public string Location { get; set; }
	public DateTime StartEvent { get; set; }
	public DateTime EndEvent { get; set; }
	public Guid Host { get; set; }
	public Guid AssociatedClubs { get; set; }
	public ICollection<User> Attendees { get; set; } = new List<User>();
}