using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface ICommentRepository
{
    public Task<bool> AddComment(Comments comments);
    public Task<Comments> GetCommentsById(Guid CommentId);
    public Task<IList<Comments>> GetCommentsByPostId(Guid PostId);
    public Task<Comments> UpdateComment(Comments comments);
    public Task<bool> DeleteComment(Comments comments);
}