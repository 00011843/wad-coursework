using System;
using System.Collections.Generic;
using System.Text;
using EventHubAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHubAPI.DAL
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Event> Events { get;set; }
    }
}
