using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IUserRepository
{
    public Task<User> RegisterUser(User User);
    public Task<User> EditUser(User User);
    public Task<User> GetUserByID(Guid Id);
    public Task<bool> GetUserByUserName(string UserName);
    public Task<bool> GetUserByEmail(string email);
    public Task<bool> DeleteUser(User User);
    public Task<User> LogIn(string email, string password);
    public Task<User> SignUp(string email, string password);
    public Task<bool> ChangePassword(Guid userId,string newPassword);
    public Task<bool> UpdateProfilePic(Guid userId, string imagePath);
    public Task<bool> UpdateBio(Guid userId, string Bio);
    public Task<bool> FollowUser(Guid FollowersId, Guid FollowingId);
    public Task<bool> UnFollowUser(Guid FollowersId, Guid FollowingId);
    public Task<IList<UserFollow>> GetAllFollowers();
    public Task<IList<User>> UsersSuggestion(Guid UserId);
}