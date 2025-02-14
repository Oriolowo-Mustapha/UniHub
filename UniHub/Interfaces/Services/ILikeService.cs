using UniHub.DTOs;

namespace UniHub.Interfaces.Services;

public interface ILikeService
{
    public Task<BaseResponse<bool>> AddLikes (CreateLikesRequestModel model);
    public Task<BaseResponse<bool>> RemoveLikes (Guid userId, Guid postId);
    public Task<BaseResponse<bool>> CheckIfLiked(Guid userId, Guid postId);
    public Task<BaseResponse<IList<LikesDto>>> GetAllLikesByUserId(Guid userId);
    public Task<BaseResponse<IList<LikesDto>>> GetAllLikesByPostId(Guid postId);
}