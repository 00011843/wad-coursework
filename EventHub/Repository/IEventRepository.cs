using EventHub.Models;
using System.Collections.Generic;


namespace EventHub.Repository
{
    public interface IEventRepository
    {
        void InsertEvent(Event ev);
        void UpdateEvent(Event ev);
        void DeleteEvent(int eventId);
        Event GetEventById(int Id);
        IEnumerable<Event> GetEvents();
        
    }
}
