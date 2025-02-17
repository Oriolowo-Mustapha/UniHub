using UniHub.DTOs;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.Interfaces.Services;

namespace UniHub.Implementations.Services;

public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IWebHostEnvironment _environment;

    public UserService(IUserRepository userRepository, IWebHostEnvironment environment)
    {
        _userRepository = userRepository;
        _environment = environment;
    }
    
    public async Task<BaseResponse<bool>> RegisterUser(CreateUserRequestModel User)
    {
        var getUserByUserName = await _userRepository.GetUserByUserName(User.UserName);
        if (getUserByUserName != null)
        {
            return new BaseResponse<bool>
            {
                Message = "UserName Already Exist",
                Status = false
            };
        }
        
        if (User.ProfilePic == null || User.ProfilePic.Length == 0)
        {
            throw new ArgumentException("No profile picture uploaded.");
        }

        // Generate a unique file name for the profile picture
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(User.ProfilePic.FileName);

        // Define the path to save the file
        string uploadFolder = Path.Combine(_environment.WebRootPath, "Uploads/ProfilePics");
        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }
        string filePath = Path.Combine(uploadFolder, fileName);

        // Save the file to the server
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await User.ProfilePic.CopyToAsync(stream);
        }

        var user = new User
        {
            DateOfCreation = DateTime.Today,
            UserName = User.UserName,
            FirstName = User.FirstName,
            Lastname = User.Lastname,
            Bio = User.Bio,
            Level = User.Level,
            ProfilePic = filePath
        };

        var userCreated = await _userRepository.RegisterUser(user);
        if (userCreated == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Unable To Register User",
                Status = false
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Student Registered Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<User>> EditUser(Guid UserId, UpdateUserRequestModel User)
    {
        var getUser = await _userRepository.GetUserByID(UserId);
        if (getUser == null)
        {
            return new BaseResponse<User>
            {
                Message = "User Doesnt Exist",
                Status = false
            };
        }

        getUser.UserName = User.UserName;
        getUser.FirstName = User.FirstName;
        getUser.Lastname = User.Lastname;
        getUser.Email = User.Email;
        getUser.Bio = User.Bio;
        getUser.Level = User.Level;

        var getUserEmailExistAlready = await _userRepository.GetUserByEmail(User.Email);
        var getUserNameExistAlready = await _userRepository.GetUserByUserName(User.Email);
        if (getUserEmailExistAlready == null || getUserNameExistAlready == null)
        {
            return new BaseResponse<User>
            {
                Message = "Email/UserName Already Exists",
                Status = false
            };
        }

        var editUser = await _userRepository.EditUser(getUser);
        if (editUser == null)
        {
            return new BaseResponse<User>
            {
                Message = "User Couldnt Be Updated",
                Status = false
            };
        }

        return new BaseResponse<User>
        {
            Message = "User Updated Successfully",
            Status = true,
            Data = editUser
        };
    }

    public async Task<BaseResponse<UserDto>> GetUserByID(Guid Id)
    {
        var getUser = await _userRepository.GetUserByID(Id);
        if (getUser == null)
        {
            return new BaseResponse<UserDto>
            {
                Message = "Student Not found",
                Status = false
            };
        }

        var user = new UserDto
        {
            Id = getUser.Id,
            UserName = getUser.UserName,
            FirstName = getUser.FirstName,
            Lastname = getUser.Lastname,
            Email = getUser.Email,
            Password = getUser.Password,
            ProfilePic = getUser.ProfilePic,
            Bio = getUser.Bio,
            Level = getUser.Level,
            NoFollowers = getUser.NoFollowers ?? 0,
            DateOfCreation = getUser.DateOfCreation
        };
        return new BaseResponse<UserDto>
        {
            Message = "User Successful Retrieved",
            Status = true,
            Data = user
        };
    }

    public async Task<BaseResponse<UserDto>> GetUserByUserName(string UserName)
    {
        var getUser = await _userRepository.GetUserByUserName(UserName);
        if (getUser == null)
        {
            return new BaseResponse<UserDto>
            {
                Message = "Student Not found",
                Status = false
            };
        }

        var user = new UserDto
        {
            Id = getUser.Id,
            UserName = getUser.UserName,
            FirstName = getUser.FirstName,
            Lastname = getUser.Lastname,
            Email = getUser.Email,
            Password = getUser.Password,
            ProfilePic = getUser.ProfilePic,
            Bio = getUser.Bio,
            Level = getUser.Level,
            NoFollowers = getUser.NoFollowers ?? 0,
            DateOfCreation = getUser.DateOfCreation
        };
        return new BaseResponse<UserDto>
        {
            Message = "User Successful Retrieved",
            Status = true,
            Data = user
        };
    }

    public async Task<BaseResponse<UserDto>> GetUserByEmail(string email)
    {
        var getUser = await _userRepository.GetUserByEmail(email);
        if (getUser == null)
        {
            return new BaseResponse<UserDto>
            {
                Message = "Student Not found",
                Status = false
            };
        }

        var user = new UserDto
        {
            Id = getUser.Id,
            UserName = getUser.UserName,
            FirstName = getUser.FirstName,
            Lastname = getUser.Lastname,
            Email = getUser.Email,
            Password = getUser.Password,
            ProfilePic = getUser.ProfilePic,
            Bio = getUser.Bio,
            Level = getUser.Level,
            NoFollowers = getUser.NoFollowers ?? 0,
            DateOfCreation = getUser.DateOfCreation
        };
        return new BaseResponse<UserDto>
        {
            Message = "User Successful Retrieved",
            Status = true,
            Data = user
        };
    }

    public async Task<BaseResponse<bool>> DeleteUser(Guid userId)
    {
        var user = await _userRepository.GetUserByID(userId);
        if (user == null)
        {
            return new BaseResponse<bool>
            {
                Message = "User not found!",
                Status = false
            };
        }

        var deletedUser = await _userRepository.DeleteUser(user);
        if (!deletedUser)
        {
            return new BaseResponse<bool>
            {
                Message = "User couldn't be deleted!",
                Status = false
            };
        }

        return new BaseResponse<bool>
        {
            Message = "User successfully deleted!",
            Status = true
        };
    }

    public async Task<BaseResponse<User>> LogIn(LogInUserRequestModel model)
    {
        var userExist = await _userRepository.GetUserByEmail(model.Email);
        if (userExist == null)
        {
            return new BaseResponse<User>
            {
                Message = "Invalid Credentials",
                Status = false
            };
        }

        var userPassword = await _userRepository.GetUserByPassword(model.Password);
        if (userPassword == null)
        {
            return new BaseResponse<User>
            {
                Message = "Invalid Credentials",
                Status = false
            };
        }

        var user = new User()
        {
            Email = model.Email,
            Password = model.Password
        };
        return new BaseResponse<User>
        {
            Message = "Logged In SuccessFul",
            Status = true,
            Data = user
        };
    }

    public async Task<BaseResponse<User>> SignUp(SignUpUserRequestModel model)
    {
        var userExist = await _userRepository.GetUserByEmail(model.Email);
        if (userExist == null)
        {
            return new BaseResponse<User>
            {
                Message = "Invalid Credentials",
                Status = false
            };
        }

        var user = new User
        {
            Email = model.Email,
            Password = model.Password
        };
        return new BaseResponse<User>
        {
            Message = "Logged In SuccessFul",
            Status = true,
            Data = user
        };
    }

    public async Task<BaseResponse<bool>> ChangePassword(Guid userId,ChangePasswordRequestModel model)
    {
        var userExist = await _userRepository.GetUserByID(userId);
        if (userExist == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Invalid Credentials",
                Status = false
            };
        }

        userExist.Password = model.Password;
        
        var updateUser = await _userRepository.EditUser(userExist);
        if (updateUser == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Password Couldnt Be Updated",
                Status = false
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Password Updated Successfully",
            Status = true,
        };
    }

    public async Task<BaseResponse<bool>> UpdateProfilePic(Guid userId,UpdateProfilePicRequestModel model)
    {
        var userExist = await _userRepository.GetUserByID(userId);
        if (userExist == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Invalid Credentials",
                Status = false
            };
        }
        
        if (model.ProfilePic == null || model.ProfilePic.Length == 0)
        {
            throw new ArgumentException("No profile picture uploaded.");
        }

        // Generate a unique file name for the profile picture
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProfilePic.FileName);

        // Define the path to save the file
        string uploadFolder = Path.Combine(_environment.WebRootPath, "Uploads/ProfilePics");
        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }
        string filePath = Path.Combine(uploadFolder, fileName);

        // Save the file to the server
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await model.ProfilePic.CopyToAsync(stream);
        }
        
        userExist.ProfilePic = filePath;
        
        var updateUser = await _userRepository.EditUser(userExist);
        if (updateUser == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Profile Pic Couldnt Be Updated",
                Status = false
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Profile Pic Updated Successfully",
            Status = true,
        };
    }

    public async Task<BaseResponse<bool>> UpdateBio(Guid userId, UpdateBioRequestModel model)
    {
        var getUser = await _userRepository.GetUserByID(userId);
        if (getUser == null)
        {
            return new BaseResponse<bool>
            {
                Message = "User Doesnt Exist",
                Status = false
            };
        }

        getUser.Bio = model.Bio;

        var editUser = await _userRepository.EditUser(getUser);
        if (editUser == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Bio Couldnt Be Updated",
                Status = false
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Bio Updated Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<bool>> FollowUser(Guid FollowersId, Guid FollowingId)
    {
        var user = await _userRepository.GetUserByID(FollowersId);
        if (user == null)
        {
            return new BaseResponse<bool>()
            {
                Message = "User Not Found",
                Status = false
            };
        }

        var follow = new UserFollow
        {
            FollowerId = FollowersId,
            FollowingID = FollowingId,
        };
        var followuser =await _userRepository.FollowUser(follow);
        if (!followuser)
        {
            return new BaseResponse<bool>
            {
                Message = "Follow UnSuccessful",
                Status = false
            };
        }

        await KeepFollowerTrack(FollowingId);
        return new BaseResponse<bool>
        {
            Message = "Follow Successful",
            Status = true
        };
    }

    private async Task<bool> KeepFollowerTrack(Guid UserId)
    {
        var user = await _userRepository.GetUserByID(UserId);
        int follower = user.NoFollowers ?? 0;
        int newFollower = follower + 1;
        user.updateNoFollowers(newFollower);
        await _userRepository.EditUser(user);
        return true;
    }
    
    private async Task<bool> KeepUnFollowerTrack(Guid UserId)
    {
        var user = await _userRepository.GetUserByID(UserId);
        int follower = user.NoFollowers ?? 0;
        int newFollower = follower - 1;
        user.updateNoFollowers(newFollower);
        await _userRepository.EditUser(user);
        return true;
    }

    public async Task<bool> CheckIfFollow(Guid followingID)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<bool>> UnFollowUser(Guid FollowersId, Guid FollowingId)
    {
        var user = await _userRepository.GetUserByID(FollowersId);
        if (user == null)
        {
            return new BaseResponse<bool>()
            {
                Message = "User Not Found",
                Status = false
            };
        }

        var follow = new UserFollow
        {
            FollowerId = FollowersId,
            FollowingID = FollowingId
        };
        var unFollowUser = await _userRepository.UnFollowUser(follow);
        if (!unFollowUser)
        {
            return new BaseResponse<bool>
            {
                Message = "UnFollow UnSuccessful",
                Status = false
            };
        }

        await KeepUnFollowerTrack(FollowingId);
        return new BaseResponse<bool>
        {
            Message = "UnFollow Successful",
            Status = true
        };
    }

    public async Task<BaseResponse<IList<UserFollow>>> GetAllFollowers()
    {
        var userFollows = await _userRepository.GetAllFollowers();
        if (!userFollows.Any())
        {
            return new BaseResponse<IList<UserFollow>>
            {
                Message = "No Followers Yet",
                Status = false
            };
        }

        var userFollow = userFollows.Select(usr => new UserFollow()
        {
            Id = usr.Id,
            FollowerId = usr.FollowerId,
            FollowingID = usr.FollowingID

        }).ToList();

        return new BaseResponse<IList<UserFollow>>
        {
            Message = "Followers successfully fetched!",
            Status = true,
            Data = userFollow
        };
    }

    public async Task<BaseResponse<IList<User>>> UsersSuggestion(Guid UserId)
    {
        var users = await _userRepository.UsersSuggestion();
        if (!users.Any())
        {
            return new BaseResponse<IList<User>>
            {
                Message = "No User Suggesstions Yet",
                Status = false
            };
        }

        var Users = users.Select(usr => new User
        {
            Id = usr.Id,
            UserName = usr.UserName,
            FirstName = usr.FirstName,
            Lastname = usr.Lastname,
            ProfilePic = usr.ProfilePic

        }).ToList();

        return new BaseResponse<IList<User>>
        {
            Message = "Users successfully fetched!",
            Status = true,
            Data = users
        };
    }
}