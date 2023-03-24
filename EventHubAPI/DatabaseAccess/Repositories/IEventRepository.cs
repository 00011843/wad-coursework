using EventHubAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubAPI.Repositories
{
    public interface IEventRepository
    {
        void CreateNewEvent(Event ev);

        IEnumerable<Event> GetAllEvents();

        Event GetEventById(int EventId);

        void DeleteEventById(int EventId);

        void UpdateEvent(Event ev);
    }
}
