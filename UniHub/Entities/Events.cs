namespace UniHub.Entities;

public class Events:BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartEvent { get; set; }
    public DateTime EndEvent { get; set; }
    public Guid Host { get; set; }
    public string? EventImage { get; set; }
    public string AssociatedClubs { get; set; }
    public ICollection<User> Attendees = new List<User>();
}