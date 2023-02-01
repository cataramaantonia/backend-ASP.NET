using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        public int Money { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
