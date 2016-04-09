using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregate
{
    public class PersonWithContactCount
    {
        public Person Person { get; set; }
        public int ContactCount { get; set; }
    }
}
