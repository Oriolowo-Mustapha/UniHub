using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IPostRepository
{
    public Task<Posts> CreatePost(Posts posts);
    public Task<Posts> GetPostById(int PostId);
    public Task<IList<Posts>> GetAllPosts();
    public Task<IList<Posts>> GetPostsByUserId_(int UserId);
    public Task<Posts> UpdatePost(Posts posts);
    public Task<bool> DeletePost (int PostId);
}