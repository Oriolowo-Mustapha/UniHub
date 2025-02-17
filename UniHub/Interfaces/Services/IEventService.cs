using UniHub.DTOs;
using UniHub.Entities;

namespace UniHub.Interfaces.Services;

public interface IEventService
{
    public Task<BaseResponse<bool>> CreateEvent(CreateEventsDtoRequestModel model);
    public Task<BaseResponse<EventsDto>> GetEventById(Guid eventId); 
    public Task<BaseResponse<Events>> UpdateEvent(Guid eventId,UpdateEventsDtoRequestModel model); 
    public Task<BaseResponse<bool>> DeleteEvent(Guid eventId); 
    public Task<BaseResponse<IList<EventsDto>>> GetEventByClubId(Guid clubId); 
}