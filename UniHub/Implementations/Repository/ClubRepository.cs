using Microsoft.EntityFrameworkCore;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.UniHubDbContext;

namespace UniHub.Implementations.Repository;

public class ClubRepository:IClubRepository
{
    private readonly UniHubContext _uniHubContext;

    public ClubRepository(UniHubContext uniHubContext)
    {
        uniHubContext = _uniHubContext;
    }
    
    public async Task<bool> CreateClub(Club club)
    {
        await _uniHubContext.Clubs.AddAsync(club);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<Club> GetClubById(Guid clubId)
    {
        return await _uniHubContext.Clubs.FindAsync(clubId);
    }
    
    public async Task<Club> GetClubByName(string clubName)
    {
        return await _uniHubContext.Clubs.FindAsync(clubName);
    }

    public async Task<Club> UpdateClub(Club club)
    {
        _uniHubContext.Clubs.Update(club);
        await _uniHubContext.SaveChangesAsync();
        return club;
    }

    public async Task<bool> DeleteClub(Club club)
    {
        _uniHubContext.Clubs.Remove(club);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> JoinClub(ClubMembers clubMembers)
    {
        await _uniHubContext.ClubMembers.AddAsync(clubMembers);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> LeaveClub(ClubMembers clubMembers)
    {
         _uniHubContext.ClubMembers.Remove(clubMembers);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<IList<ClubMembers>> GetMembersByClubId(Guid clubId)
    {
        var clubs = await _uniHubContext.ClubMembers
            .Where(clu => clu.Id == clubId)
            .Include(clu => clu.Clubs)
            .AsNoTracking()
            .ToListAsync();
        return clubs;
    }

    public async Task<IList<ClubMembers>> GetClubsByMemberId(Guid userId)
    {
        var clubs = await _uniHubContext.ClubMembers
            .Where(clu => clu.UserId == userId)
            .Include(clu => clu.Id)
            .AsNoTracking()
            .ToListAsync();
        return clubs;
    }
    
}