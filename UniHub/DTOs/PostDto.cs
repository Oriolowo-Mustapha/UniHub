using System.ComponentModel.DataAnnotations;

namespace UniHub.DTOs;

public class PostDto
{
    public Guid Id { get; set; }
    public Guid UserID { get; set; }
    public Guid ClubID { get; set; }
    public string Content { get; set; }
    public int? NoLikes { get; set; }
    public int? NoComments { get; set; }
    public string MediaUrls { get; set; }
    public DateTime DateOfCreation { get; set; }
    public ICollection<LikesDto> Likes = new List<LikesDto>();
    public ICollection<CommentDto> Comments = new List<CommentDto>();
}

public class CreatePostRequestModel
{
    [Required]
    public Guid UserID { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    [DataType(DataType.ImageUrl)]
    public IFormFile MediaUrls { get; set; }
}

public class CreateClubPostRequestModel
{
    [Required]
    public Guid UserID { get; set; }
    
    [Required]
    public Guid ClubID { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    [DataType(DataType.ImageUrl)]
    public IFormFile MediaUrls { get; set; }
}

public class UpdatePostRequestModel
{
    
    [Required]
    public string Content { get; set; }
    
    
    [DataType(DataType.ImageUrl)]
    public IFormFile MediaUrls { get; set; }
}