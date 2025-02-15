using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IUserRepository
{
    public Task<User> RegisterUser(User user);
    public Task<User> EditUser(User User);
    public Task<User> GetUserByID(Guid Id);
    public Task<bool> GetUserByUserName(string UserName);
    public Task<bool> GetUserByEmail(string email);
    public Task<bool> DeleteUser(User User);
    public Task<bool> FollowUser(UserFollow follow);
    public Task<bool> UnFollowUser(UserFollow follow);
    public Task<IList<UserFollow>> GetAllFollowers();
    public Task<IList<User>> UsersSuggestion();
}