using System.ComponentModel.DataAnnotations;

namespace UniHub.DTOs;

public class EventsDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartEvent { get; set; }
    public Guid Host { get; set; }
    public Guid AssociatedClubs { get; set; }
    public DateTime DateOfCreation { get; set; }
    public ICollection<UserDto> Attendees = new List<UserDto>();
}

public class CreateEventsDtoRequestModel
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    [DataType(DataType.ImageUrl)]
    public string Location { get; set; }
    
    [Required]
    public Guid AssociatedClubs { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartEvent { get; set; }
    
}

public class UpdateEventsDtoRequestModel
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Location { get; set; }
    
    [Required]
    public Guid AssociatedClubs { get; set; }
}