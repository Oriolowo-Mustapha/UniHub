using System.ComponentModel.DataAnnotations;

namespace UniHub.DTOs;

public class RepostDto
{
    public Guid Id { get; set; }
    public Guid OriginalPostID { get; set; }
    public Guid RepostUserID  { get; set; }
    public string? AdditionalContent { get; set; }
    public DateTime DateOfCreation { get; set; }
}

public class CreateRepostDtoRequestModel
{
    [Required]
    public Guid OriginalPostID { get; set; }
    
    [Required]
    public Guid RepostUserID  { get; set; }
    
    [Required]
    public string? AdditionalContent { get; set; }
}

public class UpdateRepostDtoRequestModel
{
    [Required]
    public Guid OriginalPostID { get; set; }
    
    [Required]
    public Guid RepostUserID  { get; set; }
    
    [Required]
    public string? AdditionalContent { get; set; }
}