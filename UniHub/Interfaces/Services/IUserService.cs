using UniHub.DTOs;
using UniHub.Entities;

namespace UniHub.Interfaces.Services;

public interface IUserService
{
    public Task<BaseResponse<bool>> RegisterUser(CreateUserRequestModel User);
    public Task<BaseResponse<User>> EditUser(Guid UserId , UpdateUserRequestModel User);
    public Task<BaseResponse<UserDto>> GetUserByID(Guid Id);
    public Task<BaseResponse<UserDto>> GetUserByUserName(string UserName);
    public Task<BaseResponse<UserDto>> GetUserByEmail(string email);
    public Task<BaseResponse<bool>> DeleteUser(Guid userId);
    public Task<BaseResponse<User>>  LogIn(LogInUserRequestModel model);
    public Task<BaseResponse<User>> SignUp(SignUpUserRequestModel model);
    public Task<BaseResponse<bool>> ChangePassword(Guid userId,ChangePasswordRequestModel model);
    public Task<BaseResponse<bool>> UpdateProfilePic(Guid userId,UpdateProfilePicRequestModel model);
    public Task<BaseResponse<bool>> UpdateBio(Guid userId, UpdateBioRequestModel model);
    public Task<BaseResponse<bool>> FollowUser(Guid FollowersId, Guid FollowingId);
    public Task<bool> CheckIfFollow(Guid followingID);
    public Task<BaseResponse<bool>> UnFollowUser(Guid FollowersId, Guid FollowingId);
    public Task<BaseResponse<IList<UserFollow>>> GetAllFollowers();
    public Task<BaseResponse<IList<User>>> UsersSuggestion(Guid UserId);   
}