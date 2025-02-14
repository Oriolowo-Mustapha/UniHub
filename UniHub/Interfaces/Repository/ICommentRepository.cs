using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface ICommentRepository
{
    public Task<Comments> AddComment(Comments comments);
    public Task<Comments> GetCommentsById(Guid CommentId);
    public Task<Comments> GetCommentsByPostId(Guid PostId);
    public Task<Comments> UpdateComment(Comments comments);
    public Task<bool> DeleteComment(Guid commentId);
}