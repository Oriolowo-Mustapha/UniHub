using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface ILikeRepository
{
    public Task<Likes> AddLikes (Likes likes);
    public Task<bool> RemoveLikes (Guid userId, Guid postId);
    public Task<bool> CheckIfLiked(Guid userId, Guid postId);
    public Task<IList<Likes>> GetAllLikesByUserId(Guid userId);
    public Task<IList<Likes>> GetAllLikesByPostId(Guid postId);
}