using System.ComponentModel.DataAnnotations;

namespace UniHub.DTOs;

public class CommentDto
{
    public Guid Id { get; set; }
    public Guid PostID { get; set; }
    public Guid UserID { get; set; } 
    public string Content { get; set; }
    public int? LikeCount { get; set; }
    public int? ReplyComment { get; set; }
    public ICollection<LikesDto> Likes = new List<LikesDto>();
}

public class CreateCommentRequestModel
{
    [Required]
    public Guid PostID { get; set; }
    
    [Required]
    public Guid UserID { get; set; } 
    
    [Required]
    [StringLength(maximumLength:500, MinimumLength = 10)]
    public string Content { get; set; }
}

public class UpdateCommentRequestModel
{
    [Required]
    [StringLength(maximumLength:500, MinimumLength = 10)]
    public string Content { get; set; }
}