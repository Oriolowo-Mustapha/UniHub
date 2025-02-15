using System.ComponentModel.DataAnnotations;

namespace UniHub.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile ProfilePic { get; set; }
        public string Bio { get; set; }
        public string Level { get; set; }
        public int? NoPosts { get; set; }
        public int? NoLikes { get; set; }
        public int? NoFollowers { get; set; }
        public DateTime DateOfCreation { get; set; }
        public ICollection<UserFollowDto> Followers { get; set; } = new List<UserFollowDto>();
        public ICollection<PostDto> Posts { get; set; } = new List<PostDto>();
        public ICollection<LikesDto> Likes { get; set; } = new List<LikesDto>();
    }
    
    public class CreateUserRequestModel
    {
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 2)]
        public string UserName { get; set; }
        
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 2)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 2)]
        public string Lastname { get; set; }
        
        
        [DataType(DataType.ImageUrl)]
        public IFormFile ProfilePic { get; set; }
        
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Bio { get; set; }
    }
    
    public class UpdateUserRequestModel
    {
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 2)]
        public string UserName { get; set; }
        
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 2)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 2)]
        public string Lastname { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Bio { get; set; }
    }

    public class UpdateProfilePicRequestModel
    {
        [DataType(DataType.ImageUrl)]
        public IFormFile ProfilePic { get; set; }
        
    }

    public class LogInUserRequestModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required] 
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class SignUpUserRequestModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required] 
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    
    public class ChangePasswordRequestModel
    {
        [Required] 
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    
    public class UpdateBioRequestModel
    {
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Bio { get; set; }
    }
}