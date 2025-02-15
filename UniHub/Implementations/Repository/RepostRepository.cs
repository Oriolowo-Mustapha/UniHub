using Microsoft.EntityFrameworkCore;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.UniHubDbContext;

namespace UniHub.Implementations.Repository;

public class RepostRepository:IRepostRepository
{
    private readonly UniHubContext _uniHubContext;

    public RepostRepository(UniHubContext uniHubContext)
    {
        uniHubContext = _uniHubContext;
    }
    
    public async Task<bool> CreateRepost(Repost Repost)
    {
        await _uniHubContext.Reposts.AddAsync(Repost);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<Repost> GetRepostById(Guid RepostId)
    {
        return await _uniHubContext.Reposts.FindAsync(RepostId);
    }

    public async Task<IList<Repost>> GetAllRepost()
    {
        var reposts = await _uniHubContext.Reposts
            .Include(rep => rep.Posts)
            .AsNoTracking()
            .ToListAsync();
        return reposts;
    }

    public async Task<IList<Repost>> GetRepostByUserId_(Guid UserId)
    {
        var reposts = await _uniHubContext.Reposts
            .Where(rep => rep.RepostUserID == UserId)
            .Include(rep => rep.Posts)
            .AsNoTracking()
            .ToListAsync();
        return reposts;
    }

    public async Task<Repost> UpdateRepost(Repost Repost)
    {
        _uniHubContext.Reposts.Update(Repost);
        await _uniHubContext.SaveChangesAsync();
        return Repost;
    }

    public async Task<bool> DeleteRepost(Repost Repost)
    {
        _uniHubContext.Reposts.Remove(Repost);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }
}