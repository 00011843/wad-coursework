using EventHubAPI.DAL;
using EventHubAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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

        private Event FindEventById(int eventId)
        {
            return __dbContext.Events.Find(eventId);
        }

        public void CreateNewEvent(Event ev)
        {
            if (ev.EventCategory != null)
            {
                ev.EventCategory = __dbContext.Categories.FirstOrDefault(c => c.Id == ev.EventCategory.Id);
            }
            __dbContext.Add(ev);
            Save();
        }

        public void DeleteEventById(int eventId)
        {
            var foundEvent = FindEventById(eventId);
            __dbContext.Events.Remove(foundEvent);
            Save();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return __dbContext.Events.Include(s => s.EventCategory).ToList();
        }

        public Event GetEventById(int eventId)
        {
            var ev = FindEventById(eventId);
            __dbContext.Entry(ev).Reference(s => s.EventCategory).Load();
            return ev;
        }

        public void UpdateEvent(Event ev)
        {
            __dbContext.Entry(ev).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
            
        }
    }
}
