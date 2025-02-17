using Microsoft.EntityFrameworkCore;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.UniHubDbContext;

namespace UniHub.Implementations.Repository;

public class PostRepository:IPostRepository
{
    private readonly UniHubContext _uniHubContext;

    public PostRepository(UniHubContext uniHubContext)
    {
        uniHubContext = _uniHubContext;
    }
    
    public async Task<bool> CreatePost(Posts posts)
    {
        await _uniHubContext.Posts.AddAsync(posts);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CreateClubPost(Posts posts)
    {
        await _uniHubContext.Posts.AddAsync(posts);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<Posts> GetPostById(Guid PostId)
    {
        return await _uniHubContext.Posts.FindAsync(PostId);
    }

    public async Task<IList<Posts>> GetAllPosts()
    {
        var posts = await _uniHubContext.Posts
            .Include(pos => pos.Reposts)
            .AsNoTracking()
            .ToListAsync();
        return posts;
    }

    public async Task<IList<Posts>> GetPostsByUserId_(Guid UserId)
    {
        var posts = await _uniHubContext.Posts
            .Where(pos => pos.UserID == UserId)
            .Include(pos => pos.Reposts)
            .AsNoTracking()
            .ToListAsync();
        return posts;
    }

    public async Task<IList<Posts>> GetPostsByClubId_(Guid ClubId)
    {
        var posts = await _uniHubContext.Posts
            .Where(pos => pos.ClubID == ClubId)
            .Include(pos => pos.Reposts)
            .AsNoTracking()
            .ToListAsync();
        return posts;
    }

    public async Task<Posts> UpdatePost(Posts posts)
    {
        _uniHubContext.Posts.Update(posts);
        await _uniHubContext.SaveChangesAsync();
        return posts;
    }

    public async Task<bool> DeletePost(Posts posts)
    {
        _uniHubContext.Posts.Remove(posts);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }
}