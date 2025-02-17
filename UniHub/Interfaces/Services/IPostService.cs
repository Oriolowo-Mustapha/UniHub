using UniHub.DTOs;
using UniHub.Entities;

namespace UniHub.Interfaces.Services;

public interface IPostService
{
    public Task<BaseResponse<bool>> CreatePost(CreatePostRequestModel model);
    public Task<BaseResponse<bool>> CreatePost(CreateClubPostRequestModel model);
    public Task<BaseResponse<PostDto>> GetPostById(Guid PostId);
    public Task<BaseResponse<IList<PostDto>>> GetAllPosts();
    public Task<BaseResponse<IList<PostDto>>> GetPostsByUserId_(Guid UserId);
    public Task<BaseResponse<IList<PostDto>>> GetPostsByClubId_(Guid ClubId);
    public Task<BaseResponse<Posts>> UpdatePost(Guid PostId, UpdatePostRequestModel model);
    public Task<BaseResponse<bool>> DeletePost (Guid PostId);
}