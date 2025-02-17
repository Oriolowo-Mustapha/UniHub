using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IClubRepository
{
    public Task<bool> CreateClub(Club club);
    public Task<Club> GetClubById(Guid clubId);
    public Task<Club> GetClubByName(string clubName);
    public Task<Club> UpdateClub(Club club);
    public Task<bool> DeleteClub(Club club);
    public Task<bool> JoinClub(ClubMembers clubMembers);
    public Task<bool> LeaveClub(ClubMembers clubMembers);
    public Task<IList<ClubMembers>> GetMembersByClubId(Guid clubId);
    public Task<IList<ClubMembers>> GetClubsByMemberId(Guid userId);
}