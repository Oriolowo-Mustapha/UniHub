using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IClubRepository
{
    public Task<bool> CreateClub(Club club);
    public Task<Club> GetClubById(Guid clubId);
    public Task<Club> UpdateClub(Club club);
    public Task<bool> DeleteClub(Club club);
    public Task<IList<Club>> GetMembersByClubId(Guid clubId);
    public Task<IList<Club>> GetClubsByMemberId(User user);
}