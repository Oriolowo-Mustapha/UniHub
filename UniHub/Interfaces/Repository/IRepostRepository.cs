using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IRepostRepository
{
    public Task<bool> CreateRepost(Repost Repost);
    public Task<Repost> GetRepostById(Guid RepostId);
    public Task<IList<Repost>> GetAllRepost();
    public Task<IList<Repost>> GetRepostByUserId_(Guid UserId);
    public Task<Repost> UpdateRepost(Repost Repost);
    public Task<bool> DeleteRepost (Repost Repost);
}