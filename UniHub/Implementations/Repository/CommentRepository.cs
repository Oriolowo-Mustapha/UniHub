using Microsoft.EntityFrameworkCore;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.UniHubDbContext;

namespace UniHub.Implementations.Repository;

public class CommentRepository:ICommentRepository
{
    private readonly UniHubContext _uniHubContext;

    public CommentRepository(UniHubContext uniHubContext)
    {
        uniHubContext = _uniHubContext;
    }
    
    public async Task<bool> AddComment(Comments comments)
    {
        await _uniHubContext.Comments.AddAsync(comments);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<Comments> GetCommentsById(Guid CommentId)
    {
        return await _uniHubContext.Comments.FindAsync(CommentId);
    }

    public async Task<IList<Comments>> GetCommentsByPostId(Guid PostId)
    {
        var comments = await _uniHubContext.Comments
            .Where(com => com.PostID == PostId)
            .Include(com => com.Likes)
            .AsNoTracking()
            .ToListAsync();
        return comments;
    }

    public async Task<Comments> UpdateComment(Comments comments)
    {
        _uniHubContext.Comments.Update(comments);
        await _uniHubContext.SaveChangesAsync();
        return comments;
    }

    public async Task<bool> DeleteComment(Comments comments)
    {
        _uniHubContext.Comments.Remove(comments);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }
}