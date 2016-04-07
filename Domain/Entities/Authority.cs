using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Authority
    {
        public int AuthorityID { get; set; }
        public int AuthorID { get; set; }
        public int EventId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Event Event { get; set; }

    }
}
