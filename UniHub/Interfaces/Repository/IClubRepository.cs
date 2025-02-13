using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IClubRepository
{
    public Task<Club> CreateClub(Club club);
    public Task<Club> GetClubById(int clubId);
    public Task<Club> UpdateClub(Club club);
    public Task<bool> DeleteClub(int clubId);
    public Task<Club> JoinClub(int clubId, int userId);
    public Task<Club> LeaveClub(int clubId, int userId);
    public Task<IList<Club>> GetMembersByClubId(int clubId);
    public Task<IList<Club>> GetClubByMemberId(int userId);
}