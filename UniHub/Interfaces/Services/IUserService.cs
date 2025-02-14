using UniHub.DTOs;
using UniHub.Entities;

namespace UniHub.Interfaces.Services;

public interface IUserService
{
    public Task<BaseResponse<bool>> RegisterUser(CreateUserRequestModel User);
    public Task<BaseResponse<User>> EditUser(Guid UserId , UpdateUserRequestModel User);
    public Task<BaseResponse<UserDto>> GetUserByID(Guid Id);
    public Task<BaseResponse<bool>> GetUserByUserName(string UserName);
    public Task<BaseResponse<bool>> GetUserByEmail(string email);
    public Task<BaseResponse<bool>> DeleteUser(UserDto userDto);
    public Task<BaseResponse<UserDto>>  LogIn(string email, LogInUserRequestModel model);
    public Task<BaseResponse<UserDto>> SignUp(SignUpUserRequestModel model);
    public Task<BaseResponse<bool>> ChangePassword(Guid userId,string newPassword, ChangePasswordRequestModel model);
    public Task<BaseResponse<bool>> UpdateProfilePic(Guid userId, string imagePath, UpdateProfilePicRequestModel model);
    public Task<BaseResponse<bool>> UpdateBio(Guid userId, string Bio, UpdateBioRequestModel model);
    public Task<BaseResponse<UserFollow>> FollowUser(Guid FollowersId, Guid FollowingId);
    public Task<BaseResponse<UserFollow>> UnFollowUser(Guid FollowersId, Guid FollowingId);
    public Task<BaseResponse<IList<UserFollow>>> GetAllFollowers();
    public Task<BaseResponse<IList<User>>> UsersSuggestion(Guid UserId);   
}