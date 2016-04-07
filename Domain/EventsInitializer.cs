using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;


namespace Domain
{
    public class EventsInitializer : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            List<Event> events = new List<Event> {
            new Event { Title = "www", AuthorID = 1 },
            new Event { Title = "ajsk", AuthorID = 2 }
            };
            events.ForEach(s => context.Events.Add(s)); context.SaveChanges();

            List<Author> authors = new List<Author> {
                new Author { Name = "Ivan", Surname = "Ivanov", Position = "QAmanager"},
                new Author { Name = "Pavlo", Surname = "Pavlov", Position = "SFT"}
            };
            authors.ForEach(a => context.Authors.Add(a)); context.SaveChanges();

            List<Authority> authorities = new List<Authority> {
                new Authority {EventId = 1, AuthorID = 2 },
                new Authority { EventId = 2, AuthorID = 1}
            };
            authorities.ForEach(au => context.Authorities.Add(au)); context.SaveChanges();
            }



        }


    }
