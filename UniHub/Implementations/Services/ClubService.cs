using UniHub.DTOs;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.Interfaces.Services;

namespace UniHub.Implementations.Services;

public class ClubService:IClubService
{
    private readonly IClubRepository _clubRepository;
    private readonly IWebHostEnvironment _environment;
    public ClubService(IClubRepository clubRepository, IWebHostEnvironment environment)
    {
        _clubRepository = clubRepository;
        _environment = environment;
    } 
    
    public async Task<BaseResponse<bool>> CreateClub(CreateClubRequestModel model)
    {
        var ifClubExistByName = _clubRepository.GetClubByName(model.ClubName);
        if (ifClubExistByName == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Club Name Already Exist",
                Status = false
            };
        }
        if (model.ProfilePic == null || model.ProfilePic.Length == 0)
        {
            throw new ArgumentException("No profile picture uploaded.");
        }

        // Generate a unique file name for the profile picture
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProfilePic.FileName);

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
            await model.ProfilePic.CopyToAsync(stream);
        }
        
        var newclub = new Club
        {
            DateOfCreation = DateTime.Today,
            ClubName = model.ClubName,
            Desciption = model.Desciption,
            CreatorID = model.CreatorID,
            MemberCount = null,
            ProfilePic = filePath
        };

        var createclub = await _clubRepository.CreateClub(newclub);
        if (createclub == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Unable To Create Club",
                Status = false
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Club Created Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<ClubDto>> GetClubById(Guid clubId)
    {
        var getclub = await _clubRepository.GetClubById(clubId);
        if (getclub == null)
        {
            return new BaseResponse<ClubDto>
            {
                Message = "Club Not found",
                Status = false
            };
        }
        
        var clubs = new ClubDto
        {
            Id = getclub.Id,
            ClubName = getclub.ClubName,
            Desciption = getclub.Desciption,
            CreatorID = getclub.CreatorID,
            MemberCount = getclub.MemberCount,
            ProfilePic = getclub.ProfilePic,
            DateOfCreation = default,
            Members = null
        };
        return new BaseResponse<ClubDto>
        {
            Message = "Comments Successful Retrieved",
            Status = true,
            Data = clubs
        };
    }

    public async Task<BaseResponse<Club>> UpdateClub(Guid clubId, UpdateClubRequestModel model)
    {
        var getclub = await _clubRepository.GetClubById(clubId);
        if (getclub == null)
        {
            return new BaseResponse<Club>
            {
                Message = "User Doesnt Exist",
                Status = false
            };
        }

        getclub.ClubName = model.ClubName;
        getclub.Desciption = model.Desciption;

        var checkIfClubNameAlreadyExist = await _clubRepository.GetClubByName(model.ClubName);
        if (checkIfClubNameAlreadyExist == null )
        {
            return new BaseResponse<Club>
            {
                Message = "ClubName Already Exists",
                Status = false
            };
        }

        var editClub = await _clubRepository.UpdateClub(getclub);
        if (editClub == null)
        {
            return new BaseResponse<Club>
            {
                Message = "User Couldnt Be Updated",
                Status = false
            };
        }

        return new BaseResponse<Club>
        {
            Message = "User Updated Successfully",
            Status = true,
            Data = editClub
        };
    }

    public async Task<BaseResponse<bool>> DeleteClub(Guid clubId)
    {
        var getClub = await _clubRepository.GetClubById(clubId);
        if (getClub == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Club not found!",
                Status = false
            };
        }
        var deleteClub = await _clubRepository.DeleteClub(getClub);
        if (deleteClub == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Club Couldnt Delete",
                Status = false
            };
        }
        return new BaseResponse<bool>
        {
            Message = "Club Deleted Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<bool>> JoinClub(Guid clubId, Guid userId)
    {
        var getclub = await _clubRepository.GetClubById(clubId);
        if (getclub == null)
        {
            return new BaseResponse<bool>()
            {
                Message = "Club Not Found",
                Status = false
            };
        }

        var member = new ClubMembers
        {
            UserId = userId,
            ClubId = clubId
        };
        
        var clubMember =await _clubRepository.JoinClub(member);
        if (!clubMember)
        {
            return new BaseResponse<bool>
            {
                Message = "Club Joined UnSuccessful",
                Status = false
            };
        }
        
        return new BaseResponse<bool>
        {
            Message = "Club Joined Successful",
            Status = true
        };
    }

    public async Task<BaseResponse<bool>> LeaveClub(Guid clubId, Guid userId)
    {
        var getclub = await _clubRepository.GetClubById(clubId);
        if (getclub == null)
        {
            return new BaseResponse<bool>()
            {
                Message = "Club Not Found",
                Status = false
            };
        }

        var member = new ClubMembers
        {
            UserId = userId,
            ClubId = clubId
        };
        
        var clubMember =await _clubRepository.LeaveClub(member);
        if (!clubMember)
        {
            return new BaseResponse<bool>
            {
                Message = "Club Left UnSuccessful",
                Status = false
            };
        }
        
        return new BaseResponse<bool>
        {
            Message = "Club Left Successful",
            Status = true
        };
    }

    public async Task<BaseResponse<bool>> UpdateProfilePic(Guid clubId,UpdateClubProfilePicRequestModel model)
    {
        var clubExist = await _clubRepository.GetClubById(clubId);
        if (clubExist == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Invalid Credentials",
                Status = false
            };
        }
        
        if (model.ProfilePic == null || model.ProfilePic.Length == 0)
        {
            throw new ArgumentException("No profile picture uploaded.");
        }

        // Generate a unique file name for the profile picture
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProfilePic.FileName);

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
            await model.ProfilePic.CopyToAsync(stream);
        }
        
        clubExist.ProfilePic = filePath;
        
        var updateClub = await _clubRepository.UpdateClub(clubExist);
        if (updateClub == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Profile Pic Couldnt Be Updated",
                Status = false
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Profile Pic Updated Successfully",
            Status = true,
        };
    }

    public async Task<BaseResponse<IList<ClubMembers>>> GetMembersByClubId(Guid clubId)
    {
        var getClub = await _clubRepository.GetMembersByClubId(clubId);
        if (getClub == null)
        {
            return new BaseResponse<IList<ClubMembers>>
            {
                Message = "Club Not found",
                Status = false
            };
        }

        var clubs = getClub.Select(clu => new ClubMembers
        {
            UserId = clu.UserId,
            ClubId = clu.UserId
        }).ToList();
        
        return new BaseResponse<IList<ClubMembers>>
        {
            Message = "Events Successful Retrieved",
            Status = true,
            Data = clubs
        };
    }

    public async Task<BaseResponse<IList<ClubMembers>>> GetClubByUserId(Guid userId)
    {
        var getClub = await _clubRepository.GetClubsByMemberId(userId);
        if (getClub == null)
        {
            return new BaseResponse<IList<ClubMembers>>
            {
                Message = "Club Not found",
                Status = false
            };
        }

        var clubs = getClub.Select(clu => new ClubMembers
        {
            UserId = clu.UserId,
            ClubId = clu.UserId
        }).ToList();
        
        return new BaseResponse<IList<ClubMembers>>
        {
            Message = "Events Successful Retrieved",
            Status = true,
            Data = clubs
        };
    }
}