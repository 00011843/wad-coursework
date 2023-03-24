using EventHubAPI.DAL;
using EventHubAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EventHubAPI.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext __dbContext;

        public EventRepository(EventContext dbContext)
        {
            __dbContext = dbContext;
        }

        public void Save()
        {
            __dbContext.SaveChanges();
        }

        public void CreateNewEvent(Event ev)
        {
            __dbContext.Add(ev);
            Save();
        }

        public void DeleteEventById(int EventId)
        {
            var foundEvent = __dbContext.Events.Find(EventId);
            __dbContext.Events.Remove(foundEvent);
            Save();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return __dbContext.Events.ToList();
        }

        public Event GetEventById(int EventId)
        {
            return __dbContext.Events.Find(EventId);
        }

        public void UpdateEvent(Event ev)
        {
            //Modify the ev through EntityFrameworCore EnttiyState module
            __dbContext.Entry(ev).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
