using UniHub.DTOs;

namespace UniHub.Interfaces.Services;

public interface ICommentService
{
    public Task<BaseResponse<bool>> AddComment(CreateCommentRequestModel model);
    public Task<BaseResponse<CommentDto>> GetCommentsById(Guid CommentId);
    public Task<BaseResponse<CommentDto>> GetCommentsByPostId(Guid PostId);
    public Task<BaseResponse<CommentDto>> UpdateComment(Guid CommentId, UpdateCommentRequestModel model);
    public Task<BaseResponse<bool>> DeleteComment(Guid commentId);
}