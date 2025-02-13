namespace UniHub.DTOs;

public class UserFollowDto
{
    public Guid Id { get; set; }
    public Guid FollowerId { get; set; }
    public DateTime DateOfCreation { get; set; }
}