using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(string connectionString) {
            Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Authority> Authorities { get; set; }
    }
}
