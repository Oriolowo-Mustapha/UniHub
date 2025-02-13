using System.ComponentModel.DataAnnotations;

namespace UniHub.DTOs;

public class ClubDto
{
    public Guid Id { get; set; }
    public string ClubName { get; set; }
    public string Desciption { get; set; }
    public Guid CreatorID { get; set; }
    public int? MemberCount { get; set; }
    public DateTime DateOfCreation { get; set; }
    public ICollection<UserDto> Members { get; set; } = new List<UserDto>();
}

public class CreateClubRequestModel
{
    [Required]
    public string ClubName { get; set; }
    
    [Required]
    public string Desciption { get; set; }
    
    [Required]
    public Guid CreatorID { get; set; }
}

public class UpdateClubRequestModel
{
    [Required]
    public string ClubName { get; set; }
    
    [Required]
    public string Desciption { get; set; }
    
    [Required]
    public Guid CreatorID { get; set; }
}