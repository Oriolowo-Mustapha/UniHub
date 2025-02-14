using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IPostRepository
{
    public Task<Posts> CreatePost(Posts posts);
    public Task<Posts> GetPostById(Guid PostId);
    public Task<IList<Posts>> GetAllPosts();
    public Task<IList<Posts>> GetPostsByUserId_(Guid UserId);
    public Task<Posts> UpdatePost(Posts posts);
    public Task<bool> DeletePost (Guid PostId);
}