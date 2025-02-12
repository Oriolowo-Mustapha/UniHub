namespace UniHub.Entities;

public class Repost:BaseEntity
{
    public Guid OriginalPostID { get; set; }
    public Guid RepostUserID  { get; set; }
    public string? AdditionalContent { get; set; }
}