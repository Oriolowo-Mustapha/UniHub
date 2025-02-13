using UniHub.Entities;

namespace UniHub.Interfaces.Repository;

public interface IEventRepository
{
    public Task<Events> CreateEvent(Events events);
    public Task<Events> GetEventById(int eventId); 
    public Task<Events> UpdateEvent(Events events); 
    public Task<bool> DeleteEvent(int eventId); 
    public Task<Events> GetEventByUserId(int userId); 
    public Task<Events> GetEventByClubId(int clubId); 
}