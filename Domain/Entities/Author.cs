using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Domain.Entities
{
    public class Author
    {
        public int AuthorID { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Surname")]
        public string Surname { get; set; }

        [DisplayName("Position")]
        public string Position { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
