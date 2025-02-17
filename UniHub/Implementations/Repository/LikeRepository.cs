using Microsoft.EntityFrameworkCore;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.UniHubDbContext;

namespace UniHub.Implementations.Repository;

public class LikeRepository:ILikeRepository
{
    private readonly UniHubContext _uniHubContext;

    public LikeRepository(UniHubContext uniHubContext)
    {
        uniHubContext = _uniHubContext;
    }
    
    public async Task<bool> AddLikes(Likes likes)
    {
        await _uniHubContext.Likes.AddAsync(likes);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveLikes(Likes likes)
    {
        _uniHubContext.Likes.Remove(likes);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<Likes> GetLikeByPostId(Guid PostId)
    {
        return await _uniHubContext.Likes.FindAsync(PostId);
    }

    public async Task<IList<Likes>> GetAllLikesByUserId(Guid userId)
    {
        var likes = await _uniHubContext.Likes
            .Where(lik => lik.UserID == userId)
            .Include(lik => lik.Posts)
            .AsNoTracking()
            .ToListAsync();
        return likes;
    }

    public async Task<IList<Likes>> GetAllLikesByPostId(Guid postId)
    {
        var likes = await _uniHubContext.Likes
            .Where(lik => lik.PostId == postId)
            .Include(lik => lik.Posts)
            .AsNoTracking()
            .ToListAsync();
        return likes;
    }
}