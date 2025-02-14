using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IEventRepository
{
    public Task<Events> CreateEvent(Events events);
    public Task<Events> GetEventById(Guid eventId); 
    public Task<Events> UpdateEvent(Events events); 
    public Task<bool> DeleteEvent(Guid eventId); 
    public Task<Events> GetEventByUserId(Guid userId); 
    public Task<Events> GetEventByClubId(Guid clubId); 
}