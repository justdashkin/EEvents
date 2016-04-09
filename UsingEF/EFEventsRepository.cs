using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using System.Configuration;
using Domain.Entities;
using System.Data;
using System.Data.Entity;


namespace UsingEF
{
    public class EFEventsRepository
    {
        private EFDbContext context;

        public EFEventsRepository()
        {
            context = new EFDbContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        }

        //public IEnumerable<Event> GetEvents() {
        //    return context.Events;
        //}

        //public Event GetEventById(int id) {
        //    return context.Events.FirstOrDefault(x => x.EventId == id);
        //}

        //CRUD-operations
        public List<Event> GetEvents
        {

            get { return context.Events.ToList<Event>(); }
        }

        public Event GetEvent(Int32 EventId)
        {
            return context.Events.Find(EventId);
        }

        public void EditEvent(Event event1)
        {
            context.Entry(event1).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void CreateEvent(Event event1){
            context.Events.Add(event1);
            context.SaveChanges();
        }

        public void DeleteEvent (int id)
        {
            context.Events.Remove(context.Events.Find(id));
            context.SaveChanges();
        }

        //edit data about event and courses
        public void EditEvent(Event event1, String[] chosenAuthors)
        {
            //edit data about event and courses
            context.Entry(event1).State = EntityState.Modified;
            if (chosenAuthors != null)
            {
                List<Authority> ListAuthorToEvent = context.Authorities.Where(x => x.EventId == event1.EventId).ToList();
                foreach (Authority item in ListAuthorToEvent)
                    if (!chosenAuthors.Contains(item.AuthorID.ToString()))
                    {
                        context.Authorities.Remove(item);
                    }
                foreach (String itemAuthor in chosenAuthors)
                {
                    if (ListAuthorToEvent.Find(x=>x.AuthorID==Convert.ToInt32(itemAuthor)) == null)
                    {
                        context.Authorities.Add(new Authority
                        {
                            EventId = event1.EventId,
                            AuthorID = Convert.ToInt32(itemAuthor)
                        });

                    }
                }
            }
            context.SaveChanges();
        }



        public List<Author> GetAuthorsToEvent(Int32 EventId)
        {
            List<Int32> LstAuthorId = context.Authorities.Where(x => x.EventId == EventId).Select(x => x.AuthorID).ToList<Int32>();

            List<Author> LstAuthors = new List<Author>();

            foreach (Int32 id in LstAuthorId)
            {
                LstAuthors.Add(context.Authors.Find(id));
            }
            return LstAuthors;
        }

        public List<Author> GetAuthors
        {
            get { return context.Authors.ToList<Author>(); }
        }
        public List<String> GetAuthorsSurname
        {
            get { return context.Authors.Select(x => x.Surname).ToList<String>(); }
        }
    }
}