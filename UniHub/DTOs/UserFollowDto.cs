namespace UniHub.DTOs;

public class UserFollowDto
{
    public Guid Id { get; set; }
    public Guid FollowerId { get; set; }
    public Guid FollowingId { get; set; }
    public string Status {get; set;}
    public DateTime DateOfCreation { get; set; }
    public ICollection<UserDto> Followers { get; set; } = new List<UserDto>();
}