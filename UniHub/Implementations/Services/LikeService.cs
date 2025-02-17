using Microsoft.Extensions.FileSystemGlobbing.Internal;
using UniHub.DTOs;
using UniHub.Entities;
using UniHub.Enum;
using UniHub.Interfaces.Repository;
using UniHub.Interfaces.Services;

namespace UniHub.Implementations.Services;

public class LikeService:ILikeService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly IPostRepository _postRepository;

    public LikeService(INotificationRepository notificationRepository,ILikeRepository likeRepository, IPostRepository postRepository)
    {
        _notificationRepository = notificationRepository;
        _likeRepository = likeRepository;
        _postRepository = postRepository;
    }
    
    public async Task<BaseResponse<bool>> AddLikes(CreateLikesRequestModel model)
    {
        var like = new Likes
        {
            UserID = model.UserID,
            PostId = model.postId,
        };
        
        var notification = new Notifications
        {
            DateOfCreation = DateTime.Today,
            UserId = model.UserID,
            NotificationType = NotificationType.Like,
            SourceId = model.postId,
        };
        
        var likes = await _likeRepository.AddLikes(like);
        var likeNotification = await _notificationRepository.CreateNotification(notification);
        if (likes == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Unable To Like Posts",
                Status = false
            };
        }

        await KeepLikesTrack(model.postId);
        return new BaseResponse<bool>
        {
            Message = "Post Liked Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<bool>> RemoveLikes( Guid postId)
    {
        
        var likes = await _likeRepository.GetLikeByPostId(postId);
        if (likes == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Like Unavailabe",
                Status = false
            };
        }
        var removeLike = await _likeRepository.RemoveLikes(likes);
        if (!removeLike)
        {
            return new BaseResponse<bool>
            {
                Message = "Like Couldnt Be Removed",
                Status = false
            };
        }
        
        await KeepRemoveLikesTrack(postId);
        return new BaseResponse<bool>
        {
            Message = "Like Removed Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<bool>> CheckIfLiked(Guid userId, Guid postId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<IList<LikesDto>>> GetAllLikesByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<IList<LikesDto>>> GetAllLikesByPostId(Guid postId)
    {
        throw new NotImplementedException();
    }
    private async Task<bool> KeepLikesTrack(Guid PostId)
    {
        var posts = await _postRepository.GetPostById(PostId);
        int NoLikes = posts.NoLikes ?? 0;
        int NewNoLikes = NoLikes + 1;
        posts.updateNoLikes(NewNoLikes);
        await _postRepository.UpdatePost(posts);
        return true;
    }
    
    private async Task<bool> KeepRemoveLikesTrack(Guid PostId)
    {
        var posts = await _postRepository.GetPostById(PostId);
        int NoLikes = posts.NoLikes ?? 0;
        int NewNoLikes = NoLikes - 1;
        posts.updateNoLikes(NewNoLikes);
        await _postRepository.UpdatePost(posts);
        return true;
    }
}