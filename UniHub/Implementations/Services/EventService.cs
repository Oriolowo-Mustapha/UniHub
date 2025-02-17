using UniHub.DTOs;
using UniHub.Entities;
using UniHub.Interfaces.Repository;
using UniHub.Interfaces.Services;

namespace UniHub.Implementations.Services;

public class EventService:IEventService
{
    private readonly IEventRepository _eventRepository;
    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    } 
    public async Task<BaseResponse<bool>> CreateEvent(CreateEventsDtoRequestModel model)
    {
        var CheckIfeventExist = _eventRepository.GetEventByTitle(model.Title);
        if (CheckIfeventExist == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Events Title Already Exists",
                Status = false
            };
        }
        var newevent = new Events
        {
            DateOfCreation = DateTime.Now,
            Title = model.Title,
            Description = model.Description,
            Location = model.Location,
            StartEvent = model.StartEvent,
            AssociatedClubs = model.AssociatedClubs,
        };

        var events = await _eventRepository.CreateEvent(newevent);
        if (events == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Unable To Create Events",
                Status = false
            };
        }

        return new BaseResponse<bool>
        {
            Message = "Events Created Successfully",
            Status = true
        };
    }

    public async Task<BaseResponse<EventsDto>> GetEventById(Guid eventId)
    {
        var getEvent = await _eventRepository.GetEventById(eventId);
        if (getEvent == null)
        {
            return new BaseResponse<EventsDto>
            {
                Message = "Event Not found",
                Status = false
            };
        }

        var post = new EventsDto
        {
            Title = getEvent.Title,
            Description = getEvent.Description,
            Location = getEvent.Location,
            StartEvent = getEvent.StartEvent,
            Host = getEvent.Host,
            AssociatedClubs = getEvent.AssociatedClubs
        };
        return new BaseResponse<EventsDto>
        {
            Message = "Events Successful Retrieved",
            Status = true,
            Data = post
        };
    }
    

    public async Task<BaseResponse<Events>> UpdateEvent(Guid eventId, UpdateEventsDtoRequestModel model)
    {
        var getEvents = await _eventRepository.GetEventById(eventId);
        if (getEvents == null)
        {
            return new BaseResponse<Events>
            {
                Message = "Events Doesnt Exist",
                Status = false
            };
        }

        getEvents.Title = model.Title;
        getEvents.Description = model.Description;
        getEvents.Location = model.Location;
        getEvents.AssociatedClubs = model.AssociatedClubs;

        var editEvent = await _eventRepository.UpdateEvent(getEvents);
        if (editEvent == null)
        {
            return new BaseResponse<Events>
            {
                Message = "Events Couldnt Be Updated",
                Status = false
            };
        }

        return new BaseResponse<Events>
        {
            Message = "Events Updated Successfully",
            Status = true,
            Data = editEvent
        };
    }

    public async Task<BaseResponse<bool>> DeleteEvent(Guid eventId)
    {
        var events = await _eventRepository.GetEventById(eventId);
        if (events == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Event not found!",
                Status = false
            };
        }
        var deletePost = await _eventRepository.DeleteEvent(events);
        if (deletePost == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Failed to delete Event!",
                Status = false
            };
        }
        return new BaseResponse<bool>
        {
            Message = "Event deleted successfully!",
            Status = true
        };
    }
    
    public async Task<BaseResponse<IList<EventsDto>>> GetEventByClubId(Guid clubId)
    {
        var events = await _eventRepository.GetEventByClubId(clubId);
        if (!events.Any())
        {
            return new BaseResponse<IList<EventsDto>>
            {
                Message = "No Events Created Yet",
                Status = false
            };
        }

        var selectEvent = events.Select(events1 => new EventsDto
        {
            Title = events1.Title,
            Description = events1.Description,
            Location = events1.Location,
            StartEvent = events1.StartEvent,
            Host = events1.Host,
            AssociatedClubs = events1.AssociatedClubs,
            DateOfCreation = events1.DateOfCreation,
        }).ToList();

        return new BaseResponse<IList<EventsDto>>
        {
            Message = "Events successfully fetched!",
            Status = true,
            Data = selectEvent
        };
    }
}