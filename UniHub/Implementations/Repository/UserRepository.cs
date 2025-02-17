using Microsoft.EntityFrameworkCore;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.UniHubDbContext;

namespace UniHub.Implementations.Repository;

public class UserRepository:IUserRepository
{
    private readonly UniHubContext _uniHubContext;

    public UserRepository(UniHubContext uniHubContext)
    {
        uniHubContext = _uniHubContext;
    }
    
    public async Task<User> RegisterUser(User user)
    {
        await _uniHubContext.Users.AddAsync(user);
        await _uniHubContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> EditUser(User User)
    {
        _uniHubContext.Users.Update(User);
        await _uniHubContext.SaveChangesAsync();
        return User;
    }

    public async Task<User> GetUserByID(Guid Id)
    {
        return await _uniHubContext.Users.FindAsync(Id);
    }

    public async Task<User> GetUserByUserName(string UserName)
    {
        return await _uniHubContext.Users.FindAsync(UserName);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _uniHubContext.Users.FindAsync(email);
    }

    public async Task<bool> DeleteUser(User User)
    {
        _uniHubContext.Users.Remove(User);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<User> GetUserByPassword(string password)
    {
        return await _uniHubContext.Users.FindAsync(password);
    }


    public async Task<bool> FollowUser(UserFollow userFollow)
    {
        await _uniHubContext.UserFollows.AddAsync(userFollow);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CheckIfFollow(Guid followingID)
    {
        return await _uniHubContext.UserFollows.AnyAsync(usr => usr.FollowingID == followingID);
    }

    public async Task<bool> UnFollowUser(UserFollow userFollow)
    {
        _uniHubContext.UserFollows.Remove(userFollow);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<IList<UserFollow>> GetAllFollowers()
    {
        var followers = await _uniHubContext.UserFollows
            .Include(usr => usr.Followers)
            .AsNoTracking()
            .ToListAsync();
        return followers;
    }

    public async Task<IList<User>> UsersSuggestion()
    {
        var users = await _uniHubContext.Users
            .Include(usr => usr.Followers)
            .AsNoTracking()
            .ToListAsync();
        return users;
    }
}