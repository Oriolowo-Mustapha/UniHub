using UniHub.DTOs;
using UniHub.Entities;

namespace UniHub.Interfaces.Services;

public interface ICommentService
{
    public Task<BaseResponse<bool>> AddComment(CreateCommentRequestModel model);
    public Task<BaseResponse<CommentDto>> GetCommentsById(Guid commentId);
    public Task<BaseResponse<IList<CommentDto>>> GetCommentsByPostId(Guid PostId);
    public Task<BaseResponse<Comments>> UpdateComment(Guid CommentId, UpdateCommentRequestModel model);
    public Task<BaseResponse<bool>> DeleteComment(Guid commentId);
}