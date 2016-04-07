using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using System.Configuration;
using Domain.Entities;


namespace UsingEF
{
    public class EFEventsRepository
    {
        private EFDbContext context;

        public EFEventsRepository()
        {
            context = new EFDbContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        }

        public IEnumerable<Event> GetEvents() {
            return context.Events;
        }

        public Event GetEventById(int id) {
            return context.Events.FirstOrDefault(x => x.EventId == id);
        }
    }
}