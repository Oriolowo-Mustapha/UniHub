using UniHub.DTOs;
using UniHub.Entities;

namespace UniHub.Interfaces.Services;

public interface IRepostService
{
    public Task<BaseResponse<bool>> CreateRepost(CreateRepostDtoRequestModel model);
    public Task<BaseResponse<RepostDto>> GetRepostById(Guid RepostId);
    public Task<BaseResponse<IList<RepostDto>>> GetAllRepost();
    public Task<BaseResponse<IList<RepostDto>>> GetRepostByUserId_(Guid UserId);
    public Task<BaseResponse<Repost>> UpdateRepost(Guid RepostID,UpdateRepostDtoRequestModel model);
    public Task<BaseResponse<bool>> DeleteRepost (Guid RepostId);
}