namespace UniHub.Entities;

public class Message:BaseEntity
{
    public Guid StudyGroupID { get; set; }
    public Guid SenderID { get; set; }
    public string Content { get; set; }
    public string MediaUrl { get; set; }
}