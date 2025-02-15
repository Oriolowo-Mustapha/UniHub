using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface ILikeRepository
{
    public Task<bool> AddLikes (Likes likes);
    public Task<bool> RemoveLikes (Likes likes);
    public Task<IList<Likes>> GetAllLikesByUserId(Guid userId);
    public Task<IList<Likes>> GetAllLikesByPostId(Guid postId);
}