using UniHub.DTOs;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.Interfaces.Services;

namespace UniHub.Implementations.Services;

public class CommentService:ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;

    public CommentService(ICommentRepository commentRepository, IPostRepository postRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    } 
    
    public async Task<BaseResponse<bool>> AddComment(CreateCommentRequestModel model)
    {
        var newComments = new Comments
        {
            DateOfCreation = DateTime.Today,
            PostID = model.PostID,
            UserID = model.UserID,
            Content = model.Content,
            LikeCount = null
        };

        var addComment = await _commentRepository.AddComment(newComments);
        if (addComment == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Unable To Add Comment",
                Status = false
            };
        }

        await KeepCommentTrack(model.PostID);
        return new BaseResponse<bool>
        {
            Message = "Comment Added Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<CommentDto>> GetCommentsById(Guid commentId)
    {
        var getComment = await _commentRepository.GetCommentsById(commentId);
        if (getComment == null)
        {
            return new BaseResponse<CommentDto>
            {
                Message = "Comments Not found",
                Status = false
            };
        }

        var comments = new CommentDto
        {
            Id = getComment.Id,
            PostID = getComment.PostID,
            UserID = getComment.UserID,
            Content = getComment.Content,
            LikeCount = getComment.LikeCount
        };
        return new BaseResponse<CommentDto>
        {
            Message = "Comments Successful Retrieved",
            Status = true,
            Data = comments
        };
    }

    public async Task<BaseResponse<IList<CommentDto>>> GetCommentsByPostId(Guid PostId)
    {
        var getComment = await _commentRepository.GetCommentsByPostId(PostId);
        if (getComment == null)
        {
            return new BaseResponse<IList<CommentDto>>
            {
                Message = "Comments Not found",
                Status = false
            };
        }

        var comments = getComment.Select(com => new CommentDto
        {
            Id = com.Id,
            PostID = com.PostID,
            UserID = com.UserID,
            Content = com.Content,
            LikeCount = com.LikeCount
        }).ToList();
        
        return new BaseResponse<IList<CommentDto>>
        {
            Message = "Comments Successful Retrieved",
            Status = true,
            Data = comments
        };
    }

    public async Task<BaseResponse<Comments>> UpdateComment(Guid CommentId, UpdateCommentRequestModel model)
    {
        var getComment = await _commentRepository.GetCommentsById(CommentId);
        if (getComment == null)
        {
            return new BaseResponse<Comments>
            {
                Message = "Comments Doesnt Exist",
                Status = false
            };
        }

        getComment.Content = model.Content;

        var updateEvent = await _commentRepository.UpdateComment(getComment);
        if (updateEvent == null)
        {
            return new BaseResponse<Comments>
            {
                Message = "Comments Couldnt Be Updated",
                Status = false
            };
        }

        return new BaseResponse<Comments>
        {
            Message = "Events Updated Successfully",
            Status = true,
            Data = updateEvent
        };
    }

    public async Task<BaseResponse<bool>> DeleteComment(Guid commentId)
    {
        var comment = await _commentRepository.GetCommentsById(commentId);
        if (comment == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Comment not found!",
                Status = false
            };
        }
        var deleteComments = await _commentRepository.DeleteComment(comment);
        if (deleteComments == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Failed to Comments!",
                Status = false
            };
        }
        return new BaseResponse<bool>
        {
            Message = "Comment deleted successfully!",
            Status = true
        };
    }
    
    private async Task<bool> KeepCommentTrack(Guid PostId)
    {
        var posts = await _postRepository.GetPostById(PostId);
        int NoComments = posts.NoComments ?? 0;
        int NewNoComments = NoComments + 1;
        posts.updateNoComment(NewNoComments);
        await _postRepository.UpdatePost(posts);
        return true;
    }
    
    private async Task<bool> KeepNoCommentTrack(Guid PostId)
    {
        var posts = await _postRepository.GetPostById(PostId);
        int NoComments = posts.NoComments ?? 0;
        int NewNoComments = NoComments - 1;
        posts.updateNoComment(NewNoComments);
        await _postRepository.UpdatePost(posts);
        return true;
    }
}