using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IUserRepository
{
    public Task<User> RegisterUser(User user);
    public Task<User> EditUser(User User);
    public Task<User> GetUserByID(Guid Id);
    public Task<User> GetUserByUserName(string UserName);
    public Task<User> GetUserByEmail(string email);
    public Task<bool> DeleteUser(User User);
    public Task<User> GetUserByPassword(string password);
    public Task<bool> FollowUser(UserFollow follow);
    public Task<bool> CheckIfFollow(Guid followingID);
    public Task<bool> UnFollowUser(UserFollow follow);
    public Task<IList<UserFollow>> GetAllFollowers();
    public Task<IList<User>> UsersSuggestion();
}