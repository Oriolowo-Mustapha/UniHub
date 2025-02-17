using UniHub.DTOs;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.Interfaces.Services;

namespace UniHub.Implementations.Services;

public class PostService:IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IWebHostEnvironment _environment;

    public PostService(IPostRepository postRepository, IWebHostEnvironment environment)
    {
        _postRepository = postRepository;
        _environment = environment;
    }
    
    public async Task<BaseResponse<bool>> CreatePost(CreatePostRequestModel model)
    {
        if (model.MediaUrls == null || model.MediaUrls.Length == 0)
        {
            throw new ArgumentException("No profile picture uploaded.");
        }

        // Generate a unique file name for the profile picture
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.MediaUrls.FileName);

        // Define the path to save the file
        string uploadFolder = Path.Combine(_environment.WebRootPath, "Uploads/ProfilePics");
        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }
        string filePath = Path.Combine(uploadFolder, fileName);

        // Save the file to the server
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await model.MediaUrls.CopyToAsync(stream);
        }
        
        var post = new Posts
        {
            DateOfCreation = DateTime.Today,
            UserID = model.UserID,
            Content = model.Content,
            MediaUrls = filePath
        };

        var userCreated = await _postRepository.CreatePost(post);
        if (userCreated == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Unable To Create User",
                Status = false
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Post Created Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<bool>> CreatePost(CreateClubPostRequestModel model)
    {
        if (model.MediaUrls == null || model.MediaUrls.Length == 0)
        {
            throw new ArgumentException("No profile picture uploaded.");
        }

        // Generate a unique file name for the profile picture
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.MediaUrls.FileName);

        // Define the path to save the file
        string uploadFolder = Path.Combine(_environment.WebRootPath, "Uploads/ProfilePics");
        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }
        string filePath = Path.Combine(uploadFolder, fileName);

        // Save the file to the server
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await model.MediaUrls.CopyToAsync(stream);
        }
        
        var post = new Posts
        {
            DateOfCreation = DateTime.Today,
            UserID = model.UserID,
            ClubID = model.ClubID,
            Content = model.Content,
            MediaUrls = filePath
        };

        var userCreated = await _postRepository.CreatePost(post);
        if (userCreated == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Unable To Create User",
                Status = false
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Post Created Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<PostDto>> GetPostById(Guid PostId)
    {
        var getPost = await _postRepository.GetPostById(PostId);
        if (getPost == null)
        {
            return new BaseResponse<PostDto>
            {
                Message = "Post Not found",
                Status = false
            };
        }

        var post = new PostDto
        {
            Id = getPost.Id,
            UserID = getPost.UserID,
            Content = getPost.Content,
            NoLikes = getPost.NoLikes,
            NoComments = getPost.NoComments,
            MediaUrls = getPost.MediaUrls,
            DateOfCreation = getPost.DateOfCreation,
        };
        return new BaseResponse<PostDto>
        {
            Message = "Post Successful Retrieved",
            Status = true,
            Data = post
        };
    }

    public async Task<BaseResponse<IList<PostDto>>> GetAllPosts()
    {
        var posts = await _postRepository.GetAllPosts();
        if (!posts.Any())
        {
            return new BaseResponse<IList<PostDto>>
            {
                Message = "No Posts Created Yet",
                Status = false
            };
        }

        var Posts = posts.Select(pos => new PostDto()
        {
            DateOfCreation = DateTime.Today,
            UserID = pos.UserID,
            Content = pos.Content,
            NoLikes = pos.NoLikes,
            NoComments = pos.NoComments,
            MediaUrls = pos.MediaUrls
        }).ToList();

        return new BaseResponse<IList<PostDto>>
        {
            Message = "Users successfully fetched!",
            Status = true,
            Data = Posts
        };
    }

    public async Task<BaseResponse<IList<PostDto>>> GetPostsByUserId_(Guid UserId)
    {
        var posts = await _postRepository.GetPostsByUserId_(UserId);
        if (!posts.Any())
        {
            return new BaseResponse<IList<PostDto>>
            {
                Message = "No Posts Created Yet",
                Status = false
            };
        }

        var Posts = posts.Select(pos => new PostDto()
        {
            DateOfCreation = pos.DateOfCreation,
            UserID = pos.UserID,
            Content = pos.Content,
            NoLikes = pos.NoLikes,
            NoComments = pos.NoComments,
            MediaUrls = pos.MediaUrls
        }).ToList();

        return new BaseResponse<IList<PostDto>>
        {
            Message = "Post successfully fetched!",
            Status = true,
            Data = Posts
        };
    }

    public async Task<BaseResponse<IList<PostDto>>> GetPostsByClubId_(Guid ClubId)
    {
        var posts = await _postRepository.GetPostsByClubId_(ClubId);
        if (!posts.Any())
        {
            return new BaseResponse<IList<PostDto>>
            {
                Message = "No Posts Created Yet",
                Status = false
            };
        }

        var Posts = posts.Select(pos => new PostDto()
        {
            DateOfCreation = pos.DateOfCreation,
            UserID = pos.UserID,
            Content = pos.Content,
            NoLikes = pos.NoLikes,
            NoComments = pos.NoComments,
            MediaUrls = pos.MediaUrls
        }).ToList();

        return new BaseResponse<IList<PostDto>>
        {
            Message = "Post successfully fetched!",
            Status = true,
            Data = Posts
        };
    }

    public async Task<BaseResponse<Posts>> UpdatePost(Guid PostId, UpdatePostRequestModel model)
    {
        var getPosts = await _postRepository.GetPostById(PostId);
        if (getPosts == null)
        {
            return new BaseResponse<Posts>
            {
                Message = "Post Doesnt Exist",
                Status = false
            };
        }
        
        // Generate a unique file name for the profile picture
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.MediaUrls.FileName);

        // Define the path to save the file
        string uploadFolder = Path.Combine(_environment.WebRootPath, "Uploads/ProfilePics");
        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }
        string filePath = Path.Combine(uploadFolder, fileName);

        // Save the file to the server
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await model.MediaUrls.CopyToAsync(stream);
        }
        
        getPosts.Content = model.Content;
        getPosts.MediaUrls = filePath;

        var editPost = await _postRepository.UpdatePost(getPosts);
        if (editPost == null)
        {
            return new BaseResponse<Posts>
            {
                Message = "Post Couldnt Be Updated",
                Status = false
            };
        }

        return new BaseResponse<Posts>
        {
            Message = "User Updated Successfully",
            Status = true,
            Data = editPost
        };
    }

    public async Task<BaseResponse<bool>> DeletePost(Guid PostId)
    {
        var post = await _postRepository.GetPostById(PostId);
        if (post == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Post not found!",
                Status = false
            };
        }
        var deletePost = await _postRepository.DeletePost(post);
        if (deletePost == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Failed to delete Post!",
                Status = false
            };
        }
        return new BaseResponse<bool>
        {
            Message = "Post deleted successfully!",
            Status = true
        };
    }
}