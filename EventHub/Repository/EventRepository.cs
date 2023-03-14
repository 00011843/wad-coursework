using static EventHub.Repository.EventRepository;
using System.Collections.Generic;
using EventHub.Models;
using EventHub.DAL;
using System.Linq;

namespace EventHub.Repository
{
    public class EventRepository: IEventRepository
    {
        
        private readonly EventContext _dbContext;
        public EventRepository(EventContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteEvent(int eventId)
        {
            var ev = _dbContext.Events.Find(eventId);
            _dbContext.Events.Remove(ev);
            Save();
        }
        public Event GetEventById(int eventId)
        {
            var prod = _dbContext.Events.Find(eventId);
            //_dbContext.Entry(prod).Reference(s => s.EventCategory).Load();
            return prod;
        }
        public IEnumerable<Event> GetEvents()
        {
            return _dbContext.Events.ToList();
            //.Include(s => s.EventCategory).ToList();
        }
        public void InsertEvent(Event ev)
        {
            ev.EventCategory =
            _dbContext.Categories.Find(ev.EventCategory.Id);
            _dbContext.Add(ev);
            Save();
        }
        public void UpdateEvent(Event ev)
        {
            _dbContext.Entry(ev).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        
    }
}
