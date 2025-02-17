using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IEventRepository
{
    public Task<bool> CreateEvent(Events events);
    public Task<Events> GetEventById(Guid eventId); 
    public Task<Events> GetEventByTitle(string Title); 
    public Task<Events> UpdateEvent(Events events); 
    public Task<bool> DeleteEvent(Events events); 
    public Task<IList<Events>> GetEventByClubId(Guid clubId); 
}