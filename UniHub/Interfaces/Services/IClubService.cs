using UniHub.DTOs;
using UniHub.Entities;

namespace UniHub.Interfaces.Services;

public interface IClubService
{
    public Task<BaseResponse<bool>> CreateClub(CreateClubRequestModel model);
    public Task<BaseResponse<ClubDto>> GetClubById(Guid clubId);
    public Task<BaseResponse<Club>> UpdateClub(Guid clubId,UpdateClubRequestModel model);
    public Task<BaseResponse<bool>> DeleteClub(Guid clubId);
    public Task<BaseResponse<bool>> JoinClub(Guid clubId, Guid userId);
    public Task<BaseResponse<bool>> LeaveClub(Guid clubId, Guid userId);
    public Task<BaseResponse<bool>> UpdateProfilePic(Guid clubId,UpdateClubProfilePicRequestModel model);
    public Task<BaseResponse<IList<ClubMembers>>> GetMembersByClubId(Guid clubId);
    public Task<BaseResponse<IList<ClubMembers>>> GetClubByUserId(Guid userId);
}