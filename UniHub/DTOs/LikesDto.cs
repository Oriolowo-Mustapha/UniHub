using System.ComponentModel.DataAnnotations;

namespace UniHub.DTOs;

public class LikesDto
{
    public Guid Id { get; set; }
    public Guid UserID { get; set; }
    public Guid postId { get; set; }
    public Guid CommentsId { get; set; }
    public DateTime DateOfCreation { get; set; }
}

public class CreateLikesRequestModel
{
    [Required]
    public Guid UserID { get; set; }
    
    [Required]
    public Guid postId { get; set; }
    
    [Required]
    public Guid CommentsId { get; set; }
}