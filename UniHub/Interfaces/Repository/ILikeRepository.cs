using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface ILikeRepository
{
    public Task<Likes> AddLikes (Likes likes);
    public Task<bool> RemoveLikes (int userId, int postId);
    public Task<bool> CheckIfLiked(int userId, int postId);
    public Task<IList<Likes>> GetAllLikesByUserId();
    public Task<IList<Likes>> GetAllLikesByPostId();
}