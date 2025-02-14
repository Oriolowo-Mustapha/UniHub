using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IClubRepository
{
    public Task<Club> CreateClub(Club club);
    public Task<Club> GetClubById(Guid clubId);
    public Task<Club> UpdateClub(Club club);
    public Task<bool> DeleteClub(Guid clubId);
    public Task<Club> JoinClub(Guid clubId, Guid userId);
    public Task<Club> LeaveClub(Guid clubId, Guid userId);
    public Task<IList<Club>> GetMembersByClubId(Guid clubId);
    public Task<IList<Club>> GetClubByMemberId(Guid userId);
}