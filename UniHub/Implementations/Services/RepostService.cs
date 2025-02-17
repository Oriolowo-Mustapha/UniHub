using UniHub.DTOs;
using UniHub.Entities;
using UniHub.Interfaces.Services;

namespace UniHub.Implementations.Services;

public class RepostService:IRepostService
{
    public async Task<BaseResponse<bool>> CreateRepost(CreateRepostDtoRequestModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<RepostDto>> GetRepostById(Guid RepostId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<IList<RepostDto>>> GetAllRepost()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<IList<RepostDto>>> GetRepostByUserId_(Guid UserId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Repost>> UpdateRepost(Guid RepostID, UpdateRepostDtoRequestModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<bool>> DeleteRepost(Guid RepostId)
    {
        throw new NotImplementedException();
    }
}