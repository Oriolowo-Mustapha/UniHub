using Microsoft.EntityFrameworkCore;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.UniHubDbContext;

namespace UniHub.Implementations.Repository;

public class EventRepository:IEventRepository
{
    private readonly UniHubContext _uniHubContext;

    public EventRepository(UniHubContext uniHubContext)
    {
        uniHubContext = _uniHubContext;
    }
    
    public async Task<bool> CreateEvent(Events events)
    {
        await _uniHubContext.Events.AddAsync(events);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<Events> GetEventById(Guid eventId)
    {
        return await _uniHubContext.Events.FindAsync(eventId);
    }

    public async Task<Events> GetEventByTitle(string Title)
    {
        return await _uniHubContext.Events.FindAsync(Title);
    }

    public async Task<Events> UpdateEvent(Events events)
    {
        _uniHubContext.Events.Update(events);
        await _uniHubContext.SaveChangesAsync();
        return events;
    }

    public async Task<bool> DeleteEvent(Events events)
    {
        _uniHubContext.Events.Remove(events);
        await _uniHubContext.SaveChangesAsync();
        return true;
    }

    public async Task<IList<Events>> GetEventByClubId(Guid clubId)
    {
        var events = await _uniHubContext.Events
            .Where(eve => eve.AssociatedClubs == clubId)
            .Include(eve => eve.AssociatedClubs)
            .AsNoTracking()
            .ToListAsync();
        return events;
    }
}