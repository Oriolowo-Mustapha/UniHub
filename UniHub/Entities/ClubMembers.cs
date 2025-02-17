namespace UniHub.Entities;

public class ClubMembers:BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ClubId { get; set; }
    public ICollection<Club> Clubs { get; set; } = new List<Club>();
}