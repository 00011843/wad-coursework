using Microsoft.EntityFrameworkCore;
using EventHub.Models;

namespace EventHub.DAL
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions<EventContext> o) : base(o) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
